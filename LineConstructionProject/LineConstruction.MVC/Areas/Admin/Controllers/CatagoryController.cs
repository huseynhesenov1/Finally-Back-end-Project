using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
    public class CatagoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;
		private readonly IMapper _mapper;

		public CatagoryController(ICatagoryService catagoryService, IMapper mapper)
		{
			_catagoryService = catagoryService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
        {
            ICollection<Catagory> catagories = await _catagoryService.GetAllAsync();
            return View(catagories);
        }
		public async Task<IActionResult> Recycle()
		{
			ICollection<Catagory> catagory = await _catagoryService.GetAllDeletedAsync();
			return View(catagory);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CatagoryDTO catagoryDTO)
		{
			await _catagoryService.CreateAsync(catagoryDTO);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> SoftDelete(int id)
		{
			try
			{
				await _catagoryService.SoftDeleteAsync(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
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
				Catagory catagory = await _catagoryService.GetByIdAsync(id);
				CatagoryDTO catagoryDTO = _mapper.Map<CatagoryDTO>(catagory);
				return View(catagoryDTO);
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");
			}

		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, CatagoryDTO catagoryDTO)
		{
			try
			{
				await _catagoryService.UpdateAsync(id, catagoryDTO);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");
			}
		}
		public async Task<IActionResult> Detail(int id)
		{
			try
			{
				Catagory catagory = await _catagoryService.GetByIdAsync(id);
				return View(catagory);
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");

			}
		}
		public async Task<IActionResult> Restore(int id)
		{

			try
			{
				await _catagoryService.RestoreAsync(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");

			}
		}
	}
}
