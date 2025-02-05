using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
