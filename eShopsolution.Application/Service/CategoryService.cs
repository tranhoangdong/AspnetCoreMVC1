using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Linq;

namespace eShopSolution.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _eShopDbContext;

        public CategoryService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public List<CategoryDTO> GetAllCategory( bool filterProducts = false)
        {
            var query = _eShopDbContext.Categories.AsQueryable();

            if (filterProducts)
            {
                query = query.Where(c => c.Products.Any());
            }
            var category = query.ToList().Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return category;

        }

        public CategoryDTO AddCategorys(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            };
            _eShopDbContext.Categories.Add(category);
            _eShopDbContext.SaveChanges();
            categoryDTO.Id = category.Id;
            return categoryDTO;
        }

    }
}
