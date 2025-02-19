using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorPage(int? code = null)
        {
            if (code == null)
            {
                code = 500; 
            }

            ViewBag.ErrorCode = code;
            return View();
        }
    }
}
