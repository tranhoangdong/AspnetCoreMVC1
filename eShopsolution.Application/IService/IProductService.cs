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
        List<Product> GetAllProducts(int? categoryId, string name = "", string priceFilter = "", string sortColumn = "", string sortOrder = "");
        Product GetProductbyId(int productId);
        public void DeleteProduct(int productId);
        Task<bool> UpdateProductAsync(ProductDTO productDto);
        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize);
        public int GetTotalProducts();
        Task<ProductDTO> AddProductAsync(ProductDTO productDto);
        Task<List<ProductDTO>> GetProductImageAsync();
        Task<bool> BulkUpdateProductsAsync(List<int> productIds, int stock, decimal price);
        List<Product> GetProduct(List<int> productid);
        Task<List<ProductDTO>> GetNameProductByListIdAsync(List<int> productIds);
    }
}
