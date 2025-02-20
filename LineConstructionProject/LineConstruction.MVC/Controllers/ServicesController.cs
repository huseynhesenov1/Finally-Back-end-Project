using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.BLa.ViewModels;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LineConstruction.MVC.Controllers
{
	public class ServicesController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IOurServiceService _ourServiceService;
		private readonly IOurTeamService _ourTeamService;
        private readonly TelegramLogService _telegramLogService;
        public ServicesController(IOurServiceService ourServiceService, IOurTeamService ourTeamService, IOrderService orderService, TelegramLogService telegramLogService)
        {

            _ourServiceService = ourServiceService;
            _ourTeamService = ourTeamService;
            _orderService = orderService;
            _telegramLogService = telegramLogService;
        }

        public async Task<IActionResult> Index()
		{
			ICollection<OurService> ourServices = await _ourServiceService.GetAllAsync();
			ViewBag.OurServices = new SelectList(await _ourServiceService.GetAllAsync(), "Id", "Title");
			ViewBag.OurTeams = new SelectList(await _ourTeamService.GetAllAsync(), "Id", "FullName");
			ServiceVM serviceVM = new ServiceVM
			{
				Order = new OrderDTO(),  
				OurServices = ourServices
			};

			return View(serviceVM);
		}
		[HttpPost]
		public async Task<IActionResult> Index(ServiceVM serviceVM)
		{
            if (!ModelState.IsValid)
            {
				ModelState.AddModelError(string.Empty , "ModelState is not Valid");
				ViewBag.OurServices = new SelectList(await _ourServiceService.GetAllAsync(), "Id", "Title");
				ViewBag.OurTeams = new SelectList(await _ourTeamService.GetAllAsync(), "Id", "FullName");
                
                return View(serviceVM);
            }
			try
			{
				await _orderService.CreateAsync(serviceVM.Order);
				await _telegramLogService.LogAsync(
	$" Ünvana usta çağırıldı {(User.Identity?.Name != null ? $"{User.Identity.Name} terefinden " : "")}{DateTime.UtcNow.AddHours(4)}");

                return RedirectToAction("Index");
			}
			catch
			{
				return RedirectToAction("Error");
			}
       
		}
		public IActionResult Error()
		{
			return View();
		}
	}
}
