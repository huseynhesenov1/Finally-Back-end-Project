using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
