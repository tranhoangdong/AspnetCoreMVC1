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

        public IActionResult GetAllProduct()
        {
            var products = _productService.GetAllProducts();
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
            var product = _productService.GetProductbyID(id);
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

            return View(productViewModel);
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
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            var product = new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Stock = productViewModel.Stock
            };

            await _productService.AddProductAsync(product); 

            return RedirectToAction("GetAllProduct");
        }

        [HttpGet]
        public IActionResult GetProductbyName(string name, string priceFilter)
        {
            var products = _productService.GetAllProducts()
                                          .Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (priceFilter == "above100")
            {
                products = products.Where(p => p.Price > 100);
            }
            else if (priceFilter == "below100")
            {
                products = products.Where(p => p.Price <= 100);
            }

            var productViewModels = products.Select(p => new ProductViewModel
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return PartialView("_ProductListPartial", productViewModels);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductbyID(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id); 
            return RedirectToAction("GetAllProduct");
        }

    }


}

