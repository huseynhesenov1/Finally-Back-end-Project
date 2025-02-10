using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    [Area("Admin")]
	public class OurServiceController : Controller
    {
        private readonly IOurServiceService _ourServiceService;
        private readonly IMapper _mapper;

        public OurServiceController(IOurServiceService ourServiceService, IMapper mapper)
        {
            _ourServiceService = ourServiceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<OurService> ourService = await _ourServiceService.GetAllAsync();
            return View(ourService);
        }

        public async Task<IActionResult> Recycle()
        {
            ICollection<OurService> ourService = await _ourServiceService.GetAllDeletedAsync();
            return View(ourService);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OurServiceDTO ourServiceDTO)
        {
            await _ourServiceService.CreateAsync(ourServiceDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _ourServiceService.SoftDeleteAsync(id);
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
                OurService ourService = await _ourServiceService.GetByIdAsync(id);
                OurServiceDTO ourServiceDTO = _mapper.Map<OurServiceDTO>(ourService);
                return View(ourServiceDTO);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, OurServiceDTO ourServiceDTO)
        {
            try
            {
                await _ourServiceService.UpdateAsync(id, ourServiceDTO);
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
                OurService ourService = await _ourServiceService.GetByIdAsync(id);
                return View(ourService);
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
                await _ourServiceService.RestoreAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");

            }
        }
    }
}
