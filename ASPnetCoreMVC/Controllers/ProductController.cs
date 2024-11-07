using eShopSolution.Application.IService;
using Microsoft.AspNetCore.Mvc;
using eShopSolution.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Dtos;
using eShopSolution.Application.Service;
using System;
using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult LoadProductTable(int pageNumber, int? categoryId, string priceFilter, string sortColumn, string sortOrder, string name)
        {
            const int pageSize = 10;
            try
            {
                if (pageNumber < 1 )
                {
                    throw new ArgumentException("Page number and page size must be greater than zero.");
                }

                var productsRequestDto = new ProductsRequestDto
                {
                    categoryId = categoryId,
                    priceFilter = priceFilter,
                    sortColumn = sortColumn,
                    sortOrder = sortOrder,
                    name = name,
                    pageNumber = pageNumber,
                    CurrentPage = pageNumber
                };
                var resultDTO = _productService.GetAllProducts(productsRequestDto);
                var productViewModels = resultDTO.PagedProducts.Select(p => new ProductDetailViewModel
                {
                    ID = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.CategoryName
                }).ToList();
                if (pageNumber > productsRequestDto.TotalPages && productsRequestDto.TotalPages > 0)
                {
                    pageNumber = productsRequestDto.TotalPages;
                }
                var model = new ProductListViewModel
                {
                    Products = productViewModels,
                    CurrentPage = pageNumber,
                    TotalProducts = resultDTO.TotalProducts,
                    PageSize = pageSize
                };

                return PartialView("_ProductTablePartial", model);
            }
            catch (Exception ex )
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi tải sản phẩm. Vui lòng thử lại sau." });
            }
        }

        [Authorize]
        public IActionResult Index(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var categories = _categoryService.GetAllCategories().Select(x => new CategoryViewModel
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
            var categories = _categoryService.GetAllCategories().Select(c => new CategoryViewModel
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
        [HttpGet]
        public IActionResult Addcategory()
        {
            return PartialView("_AddcategoryPartial");

        }

        [HttpPost]
        public JsonResult AddCategory(string name)
        {
           
                if (!ModelState.IsValid)
                {
                    return Json(new JsonResultResponse { success = false, message = "Dữ liệu không hợp lệ." });
                }

                _categoryService.AddCategories(name);

                return Json(new JsonResultResponse { success = true, message = "lưu category thành công" });
          
        }

        public IActionResult CreateProduct()
        {
            var  category = _categoryService.GetAllCategories().Select( c => new CategoryViewModel
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
            return RedirectToAction("Index");
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