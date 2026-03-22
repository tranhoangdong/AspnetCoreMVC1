using eShopSolution.Application.Dtos;
using System.Collections.Generic;

namespace eShopSolution.Application.IService
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategories(bool filterProducts = false);
        void AddCategories(string name);
    }
}
