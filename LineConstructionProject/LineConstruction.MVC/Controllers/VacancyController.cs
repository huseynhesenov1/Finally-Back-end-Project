using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.BLa.ViewModels;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LineConstruction.MVC.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly IAddedCVService _addedCVService;
        private readonly TelegramLogService _telegramLogService;

        public VacancyController(IVacancyService vacancyService, IAddedCVService addedCVService, TelegramLogService telegramLogService)
        {
            _vacancyService = vacancyService;
            _addedCVService = addedCVService;
            _telegramLogService = telegramLogService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Vacancy> vacancies = await _vacancyService.GetAllAsync();
            ViewBag.Vacancy = new SelectList(await _vacancyService.GetAllAsync(), "Id", "Title");


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
                ViewBag.Vacancy = new SelectList(await _vacancyService.GetAllAsync(), "Id", "Title");

                return View(vacancyVM);
            }
            try
            {
                await _addedCVService.CreateAsync(vacancyVM.AddedCVCreateDTO);
                await _telegramLogService.LogAsync( $" CV göndərildi {(User.Identity?.Name != null ? $"{User.Identity.Name} terefinden " : "")}{DateTime.UtcNow.AddHours(4)}");
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