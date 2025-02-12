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
	//[Authorize(Roles = "Admin")]

	public class TeamController : Controller
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly IMapper _mapper;

        public TeamController(IOurTeamService ourTeamService, IMapper mapper)
        {
            _ourTeamService = ourTeamService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<OurTeam> ourTeam = await _ourTeamService.GetAllAsync();
            return View(ourTeam);
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                OurTeam ourTeam = await _ourTeamService.GetByIdAsync(id);
                OurTeamUpdateDTO ourTeamUpdateDTO = _mapper.Map<OurTeamUpdateDTO>(ourTeam);
                return View(ourTeamUpdateDTO);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(OurTeamUpdateDTO ourTeamUpdateDTO)
        {
           
            try
            {
                await _ourTeamService.UpdateAsync(ourTeamUpdateDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OurTeamDTO ourTeamDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelsate is not Valid");
                return View(ourTeamDTO);
            }
            await _ourTeamService.CreateAsync(ourTeamDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Recycle()
        {
            ICollection<OurTeam> ourTeam = await _ourTeamService.GetAllDeletedAsync();
            return View(ourTeam);
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _ourTeamService.SoftDeleteAsync(id);
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
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                OurTeam ourTeam = await _ourTeamService.GetByIdAsync(id);
                return View(ourTeam);
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
                await _ourTeamService.RestoreAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");

            }
        }

    }
}
