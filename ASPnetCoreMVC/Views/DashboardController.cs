using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.Web.Views
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
