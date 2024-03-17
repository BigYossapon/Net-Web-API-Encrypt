using Microsoft.AspNetCore.Mvc;

namespace webencrypt01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
