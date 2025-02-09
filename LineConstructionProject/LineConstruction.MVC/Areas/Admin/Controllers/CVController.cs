using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CVController : Controller
	{
		private readonly IAddedCVService _addedCVService;

		public CVController(IAddedCVService addedCVService)
		{
			_addedCVService = addedCVService;
		}

		// CV-lərin siyahısını göstərir
		public async Task<IActionResult> Index()
		{
			ICollection<AddedCV> addedCVs = await _addedCVService.GetAllAsync();
			return View(addedCVs);
		}

		// CV faylını yükləyən metod
		public IActionResult Download(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return BadRequest("Fayl adı göstərilməyib.");
			}

			// wwwroot/uploads içində faylı tap
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "CV", fileName);

			// Əgər fayl yoxdursa, NotFound qaytar
			if (!System.IO.File.Exists(filePath))
			{
				return NotFound("Fayl tapılmadı!");
			}

			// MIME tipini tap (PDF, DOCX, XLSX və s. üçün)
			var provider = new FileExtensionContentTypeProvider();
			if (!provider.TryGetContentType(filePath, out var contentType))
			{
				contentType = "application/octet-stream"; // Default MIME type
			}

			// Faylı oxu və endir
			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			return File(fileBytes, contentType, fileName);
		}
	}
}
