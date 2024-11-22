using eShopsolution.Data.EF;

using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly UserManager<IdentityUser> _userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<IdentityUser> userManager)
        {
            _wishlistService = wishlistService;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var wishlist = _wishlistService.GetUserWishlist(userId);
            return View(wishlist);
        }
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _wishlistService.AddToWishlist(userId, productId);
            return Json(new JsonResultResponse
            { success = true });
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _wishlistService.RemoveFromWishlist(userId, productId);
            return Json(new JsonResultResponse
            { success = true });
        }
    }
}
