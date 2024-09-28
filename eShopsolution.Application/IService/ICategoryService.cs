using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
   public interface ICategoryService
    {
        public List<CategoryDTO> GetAllCategory();
    }
}
