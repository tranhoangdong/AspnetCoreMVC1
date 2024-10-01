using eShopSolution.Application.Dtos;
using System.Collections.Generic;

namespace eShopSolution.Application.IService
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategory(bool filterProducts = false);
    }
}
