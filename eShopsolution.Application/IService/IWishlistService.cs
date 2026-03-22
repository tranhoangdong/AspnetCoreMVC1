using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System.Collections.Generic;

namespace eShopSolution.Application.IService
{
    public interface IWishlistService
    {
        public List<WishlistDTO> GetUserWishlist(string userId);
        public void AddToWishlist(string userId, int productId);
        public void RemoveFromWishlist(string userId, int productId);
    }
}
