using eShopSolution.Application.Dtos;
using eShopSolution.Data.Emtyties;
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
