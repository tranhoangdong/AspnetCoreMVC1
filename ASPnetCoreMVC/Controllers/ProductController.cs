using eShopSolution.Application.IService;
using Microsoft.AspNetCore.Mvc;
using eShopSolution.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Dtos;
using eShopSolution.Application.Service;

namespace eShopSolution.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomAndTableServices _roomAndtableservices;


        public ProductController(IProductService productService , ICategoryService categoryService, IRoomAndTableServices roomAndTableServices)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roomAndtableservices = roomAndTableServices;
        }

        public IActionResult LoadProductTable(int? categoryId , string priceFilter, string sortColumn, string sortOrder, string name)
        {
            var products = _productService.GetAllProducts(categoryId , priceFilter, sortColumn, sortOrder,name );
            var productViewModels = products.Select(p => new ProductDetailViewModel
            {
                ID = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category?.Name
            }).ToList();
            return PartialView("_ProductTablePartial", productViewModels);
        }

        public IActionResult Index(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var categories = _categoryService.GetAllCategory().Select(x => new CategoryViewModel
            {
                Id = x.Id,
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
            var categories = _categoryService.GetAllCategory().Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            var productViewModel = new ProductDetailViewModel
            {
                ID = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = product.Category?.Name
            };
            var allProductViewModel = new AllProductViewModel
            {
                Product = productViewModel,
                Categories = categories

            };

            return PartialView("_EditProductPartial", allProductViewModel);
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
                Stock = productViewModel.Stock,
                CategoryId = productViewModel.CategoryId
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
            var  category = _categoryService.GetAllCategory().Select( c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            var allproductviewmodel = new EditProductPartialViewModel
            {
                Categories = category,
            };
            return PartialView("_CreateProductPartial", allproductviewmodel);
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
                Stock = productViewModel.Stock,
                CategoryId = productViewModel.CategoryId
            };

            await _productService.AddProductAsync(productDto); 

            return RedirectToAction("Index");
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

        public async Task<IActionResult> GetBulkUpdate(string ids)
        {
            var productIds = ids.Split(',').Select(x => int.Parse(x)).ToList();
            var products = await _productService.GetNameProductByListIdAsync(productIds);
            var requestViewModel = products.Select(x => new BulkUpdateRequestViewModel
            {
                Id = x.Id,
                Name = x.Name,
            })
            .ToList();  

            return PartialView("_GetBulkUpdatePartial", requestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> BulkUpdate([FromBody] DoBulkUpdateRequestViewModel request)
        {

            var productIds = request.Ids.Split(',').Select(x => int.Parse(x)).ToList();
            var result = await _productService.BulkUpdateProductsAsync(productIds, request.Stock, request.Price);
            return Json(new { success = result });
        }

        public IActionResult GetAllRoomAndTable()
        {
           var roomAndTable = _roomAndtableservices.GetAllRoomAndTable().Select(r => new RoomAndTableViewModel
           {
               Id = r.Id,
               Area = r.Area,
               Name = r.Name,
               Note = r.Note,
               OrdinalNumber =r.OrdinalNumber,
               Quantity = r.Quantity,
               StatusName = r.StatusName,
           });
            return View(roomAndTable);
        }
    }
}