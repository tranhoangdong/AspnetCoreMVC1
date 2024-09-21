using eShopSolution.Application.IService;
using Microsoft.AspNetCore.Mvc;
using ASPnetCoreMVC.Models;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;
using System;

namespace ASPnetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult GetAllProduct(string name, string priceFilter, string sortColumn, string sortOrder)
        {
            var products = _productService.GetAllProducts();
            products = _productService.FilterProducts(products, name, priceFilter);


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

            var productViewModels = products.Select(p => new ProductViewModel
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return View(productViewModels);
        }





        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetProductbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = new ProductViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            return PartialView("_EditProductPartial", productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, ProductViewModel productViewModel)
        {
            if (productViewModel == null)
            {
                return BadRequest("Product data is null");
            }

            var productDto = new ProductDTO
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Stock = productViewModel.Stock
            };

            bool isUpdated = await _productService.UpdateProductAsync(id, productDto); 

            if (!isUpdated)
            {
                return NotFound();
            }

            return RedirectToAction("GetAllProduct");
        }

        public IActionResult CreateProduct()
        {
            return PartialView("_CreateProductPartial");
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            var productDto = new ProductDTO
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Stock = productViewModel.Stock
            };

            await _productService.AddProductAsync(productDto); 

            return RedirectToAction("GetAllProduct");
        }



        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id); 
            return RedirectToAction("GetAllProduct");
        }

    }


}

