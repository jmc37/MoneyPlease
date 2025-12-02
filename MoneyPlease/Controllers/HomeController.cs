using Microsoft.AspNetCore.Mvc;

namespace MoneyPlease.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
