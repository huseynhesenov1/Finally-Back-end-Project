using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin , HR")]

	public class CVController : Controller
	{
		private readonly IAddedCVService _addedCVService;

		public CVController(IAddedCVService addedCVService)
		{
			_addedCVService = addedCVService;
		}

	
		public async Task<IActionResult> Index()
		{
			ICollection<AddedCV> addedCVs = await _addedCVService.GetAllAsync();
			return View(addedCVs);
		}

		
		public IActionResult Download(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return BadRequest("Fayl adı göstərilməyib.");
			}

			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "CV", fileName);

			if (!System.IO.File.Exists(filePath))
			{
				return NotFound("Fayl tapılmadı!");
			}

			var provider = new FileExtensionContentTypeProvider();
			if (!provider.TryGetContentType(filePath, out var contentType))
			{
				contentType = "application/octet-stream"; 
			}

			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			return File(fileBytes, contentType, fileName);
		}
	}
}
