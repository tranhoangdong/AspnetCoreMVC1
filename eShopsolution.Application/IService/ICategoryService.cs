using eShopSolution.Application.Dtos;
using System.Collections.Generic;

namespace eShopSolution.Application.IService
{
    public interface ICategoryService
    {
        public List<CategoryDTO> GetAllCategory();
    }
}
