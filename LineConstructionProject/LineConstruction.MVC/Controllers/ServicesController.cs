using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IOurServiceService _serviceService;

        public ServicesController(IOurServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<OurService> ourService = await _serviceService.GetAllAsync();
            return View(ourService);
        }
    }
}
