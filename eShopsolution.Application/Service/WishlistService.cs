using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace eShopSolution.Application.Service
{
    public class WishlistService : IWishlistService
    {
        private readonly EShopDbContext _eShopDbContext;

        public WishlistService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public List<WishlistDTO> GetUserWishlist(string userId)
        {
            return _eShopDbContext.Wishlists
                .Where(w => w.UserId == userId).Include(w => w.Product)
                .Select(w => new WishlistDTO
                {
                    ProductId = w.Product.Id,
                    ProductName = w.Product.Name,
                    ProductPrice = w.Product.Price
                })
                .ToList();
        }


        public void AddToWishlist (string userId, int productId)
        {
            bool isAlreadyInWishlist = _eShopDbContext.Wishlists.Any(w => w.UserId == userId && w.ProductId == productId);

            if (!isAlreadyInWishlist)
            {
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    ProductId = productId
                };

                _eShopDbContext.Wishlists.Add(wishlist);
                _eShopDbContext.SaveChanges();
            }
        }
        public void RemoveFromWishlist(string userId, int productId)
        {
            var wishlist = _eShopDbContext.Wishlists
                .FirstOrDefault(w => w.UserId == userId && w.ProductId == productId);

            if (wishlist != null)
            {
                _eShopDbContext.Wishlists.Remove(wishlist);
                _eShopDbContext.SaveChanges();
            }
        }
    }
}
