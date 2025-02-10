using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class VacancyController : Controller
	{
		private readonly IVacancyService _vacancyService;
		private readonly IMapper _mapper;

		public VacancyController(IMapper mapper, IVacancyService vacancyService)
		{
			_mapper = mapper;
			_vacancyService = vacancyService;
		}

		public async Task<IActionResult> Index()
		{
			 ICollection<Vacancy> vacancies = await _vacancyService.GetAllAsync();
		return View(vacancies);
		}
	public async Task<IActionResult> Recycle()
	{
		ICollection<Vacancy> vacancies = await _vacancyService.GetAllDeletedAsync();
		return View(vacancies);
	}

	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Create(VacancyDTO vacancyDTO)
	{
		await _vacancyService.CreateAsync(vacancyDTO);
		return RedirectToAction("Index");
	}
	public async Task<IActionResult> SoftDelete(int id)
	{
		try
		{
			await _vacancyService.SoftDeleteAsync(id);
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
	public async Task<IActionResult> Update(int id)
	{
		try
		{
			Vacancy vacancy = await _vacancyService.GetByIdAsync(id);
			VacancyDTO vacancyDTO = _mapper.Map<VacancyDTO>(vacancy);
			return View(vacancyDTO);
		}
		catch
		{
			return RedirectToAction("Error");
		}
	}
	[HttpPost]
	public async Task<IActionResult> Update(int id, VacancyDTO vacancyDTO)
	{
		try
		{
			await _vacancyService.UpdateAsync(id, vacancyDTO);
			return RedirectToAction("Index");
		}
		catch 
		{
			return RedirectToAction("Error");
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
	public async Task<IActionResult> Restore(int id)
	{

		try
		{
			await _vacancyService.RestoreAsync(id);
			return RedirectToAction("Index");
		}
		catch
		{
			return RedirectToAction("Error");

		}
	}
}

