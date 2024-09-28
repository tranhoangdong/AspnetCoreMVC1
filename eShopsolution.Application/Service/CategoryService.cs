using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShopSolution.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _eShopDbContext;

        public CategoryService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public List<CategoryDTO> GetAllCategory()
        {
            var category = _eShopDbContext.Categories.ToList().Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
         
            return category;
        }

   

    }
}
