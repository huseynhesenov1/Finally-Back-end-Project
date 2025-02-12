using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = "Admin, HR")]
	
	public class HomeController : Controller
	{
		

		public IActionResult Index()
		{
			return View();
		}

		

	}
}
