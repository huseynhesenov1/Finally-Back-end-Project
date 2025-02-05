using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
