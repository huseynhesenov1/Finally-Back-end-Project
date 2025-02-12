using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.ViewModels;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace LineConstruction.MVC.Controllers
{
	public class VacancyController : Controller
	{
		private readonly IVacancyService _vacancyService;
		private readonly IAddedCVService _addedCVService;

		public VacancyController(IVacancyService vacancyService, IAddedCVService addedCVService)
		{
			_vacancyService = vacancyService;
			_addedCVService = addedCVService;
		}

		public async Task<IActionResult> Index()
		{
			ICollection<Vacancy> vacancies = await _vacancyService.GetAllAsync();
			VacancyVM vacancyVM = new VacancyVM()
			{
				Vacancies = vacancies,
				AddedCVCreateDTO = new AddedCVCreateDTO()
			};
			return View(vacancyVM);
		}
		[HttpPost]
		public async Task<IActionResult> Index(VacancyVM vacancyVM)
		{
            if (!ModelState.IsValid)
            {
				ModelState.AddModelError(string.Empty, "Modelstate is not Valid");
				return View(vacancyVM);
            }
			try
			{
				await _addedCVService.CreateAsync(vacancyVM.AddedCVCreateDTO);
				return RedirectToAction("Index");
			}
			catch
			{
				return View(vacancyVM);
			}
		}
		public async Task<IActionResult> Detail(int id)
		{
			try
			{
				Vacancy vacancy = await _vacancyService.GetByIdAsync(id);
				return View(vacancy);
			}
			catch
			{
				return RedirectToAction("Error");
			}
			
		}
	}
}