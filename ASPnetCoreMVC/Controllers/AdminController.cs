using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
