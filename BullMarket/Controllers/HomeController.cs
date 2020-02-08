using Microsoft.AspNetCore.Mvc;

namespace BullMarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
