using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
