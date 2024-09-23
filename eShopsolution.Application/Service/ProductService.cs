using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eShopSolution.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext _eShopDbContext;
       

        public ProductService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
            
        }

        public List<Product> GetAllProducts( string name, string priceFilter, string sortColumn, string sortOrder)
        {
            var products = _eShopDbContext.Products.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (priceFilter == "above100")
            {
                products = products.Where(p => p.Price > 100).ToList();
            }
            else if (priceFilter == "below100")
            {
                products = products.Where(p => p.Price <= 100).ToList();
            }

            if (sortColumn == "price")
            {
                if (sortOrder == "asc")
                {
                    products = products.OrderBy(p => p.Price).ToList();
                }
                else if (sortOrder == "desc")
                {
                    products = products.OrderByDescending(p => p.Price).ToList();
                }
            }
            else if (sortColumn == "stock")
            {
                if (sortOrder == "asc")
                {
                    products = products.OrderBy(p => p.Stock).ToList();
                }
                else if (sortOrder == "desc")
                {
                    products = products.OrderByDescending(p => p.Stock).ToList();
                }
            }
            return products;
        }
    
        public Product GetProductbyId(int productId)
        {
            return _eShopDbContext.Products.FirstOrDefault(x => x.ID == productId);
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
            };
            _eShopDbContext.Products.Add(product);
           await  _eShopDbContext.SaveChangesAsync();
            return productDto;
        }
        //public List<Product> FilterProducts(List<Product> products, string name, string priceFilter, string sortColumn, string sortOrder)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        products = products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }
        //    if (priceFilter == "above100")
        //    {
        //        products = products.Where(p => p.Price > 100).ToList();
        //    }
        //    else if (priceFilter == "below100")
        //    {
        //        products = products.Where(p => p.Price <= 100).ToList();
        //    }

        //    if (sortColumn == "price")
        //    {
        //        if (sortOrder == "asc")
        //        {
        //            products = products.OrderBy(p => p.Price).ToList();
        //        }
        //        else if (sortOrder == "desc")
        //        {
        //            products = products.OrderByDescending(p => p.Price).ToList();
        //        }
        //    }
        //    else if (sortColumn == "stock")
        //    {
        //        if (sortOrder == "asc")
        //        {
        //            products = products.OrderBy(p => p.Stock).ToList();
        //        }
        //        else if (sortOrder == "desc")
        //        {
        //            products = products.OrderByDescending(p => p.Stock).ToList();
        //        }
        //    }
        //    return products;
        //}


        public async Task<bool> UpdateProductAsync(int id, ProductDTO productDto)
        {
            var existingProduct = await _eShopDbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Stock = productDto.Stock;

            _eShopDbContext.Products.Update(existingProduct);
            await _eShopDbContext.SaveChangesAsync();

            return true;
        }

        //public void DeleteProduct(int productId) 
        //{
        //    var product = _eShopDbContext.Products.FirstOrDefault(x => x.ID == productId);
        //    {
        //        if (product != null)
        //            _eShopDbContext.Products.Remove(product);
        //        _eShopDbContext.SaveChanges();
        //    }
        //}

        public void DeleteProduct(int productId)
        {
            var images = _eShopDbContext.Images.Where(x => x.ProductId == productId).ToList();
            if (images.Any())
            {
                _eShopDbContext.Images.RemoveRange(images);
            }
            var product = _eShopDbContext.Products.FirstOrDefault(x => x.ID == productId);
            if (product != null)
            {
                _eShopDbContext.Products.Remove(product);
                _eShopDbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize)
        {
            return _eShopDbContext.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public int GetTotalProducts()
        {
            return _eShopDbContext.Products.Count();
        }

        public async Task<List<ProductDTO>> GetProductImageAsync()
        {
            var products = await _eShopDbContext.Products
                .Include(p => p.Images)
                .ToListAsync();

            var productDTOs = products.Select(p => new ProductDTO
            {
                
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Images = p.Images.Select(i => new ImageDTO
                {
                    ID = i.ID,
                    Name = i.Name,
                    ProductId = i.ProductId,
                    ContentType = i.ContentType
                }).ToList()
            }).ToList();

            return productDTOs;
        }

    }

}
