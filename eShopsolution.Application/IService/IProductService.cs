using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
   public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductbyId(int productId);
        public void DeleteProduct(int productId);
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);
        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize);
        public int GetTotalProducts();
        Task<ProductDTO> AddProductAsync(ProductDTO productDto);
        Task<List<ProductDTO>> GetProductImageAsync();
        public List<Product> FilterProducts(List<Product> products, string name, string priceFilter);



    }
}
