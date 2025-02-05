using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
