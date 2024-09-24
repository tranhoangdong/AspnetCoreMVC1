using eShopSolution.Application.IService;
using Microsoft.AspNetCore.Mvc;
using ASPnetCoreMVC.Models;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;
using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace ASPnetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService , ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        //public IActionResult GetAllCategory ()
        //{
        //    var category = _categoryService.GetAllCategory().Select ( x => new CategoryViewModel
        //    {
        //        Id = x.ID,
        //        Name = x.Name
        //    });
        //    return View(category);
        //}

        public IActionResult LoadProductTable(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var products = _productService.GetAllProducts( name, priceFilter, sortColumn, sortOrder, categoryId);
            var productViewModels = products.Select(p => new ProductDetailViewModel
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category.Name
            }).ToList();
            return PartialView("_ProductTablePartial", productViewModels);
        }

        public IActionResult Index(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var categories = _categoryService.GetAllCategory().Select(x => new CategoryViewModel
            {
                Id = x.ID,
                Name = x.Name
            }).ToList();
            var allProductViewModel = new AllProductViewModel
            {
                Categories = categories,

            };

            return View(allProductViewModel);
        }
        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetProductbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = new ProductDetailViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            return PartialView("_EditProductPartial", productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDetailViewModel productViewModel)
        {
            if (productViewModel == null)
            {
                return BadRequest("Product data is null");
            }

            var productDto = new ProductDTO
            {
                Id = productViewModel.ID,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Stock = productViewModel.Stock
            };

            bool isUpdated = await _productService.UpdateProductAsync(productDto); 

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        public IActionResult CreateProduct()
        {
            return PartialView("_CreateProductPartial");
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDetailViewModel productViewModel)
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

