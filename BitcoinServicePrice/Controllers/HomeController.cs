using Microsoft.AspNetCore.Mvc;

namespace BitcoinServicePrice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
