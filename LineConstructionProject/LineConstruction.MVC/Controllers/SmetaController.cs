using LineConstruction.BLa.DTOs.SmetaDTO;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.MVC.Controllers
{
	public class SmetaController : Controller
	{
		private readonly AppDbContext _context;

		public SmetaController(AppDbContext context)
		{
			_context = context;
		}
        public IActionResult Index() { return View(); }
        public IActionResult Suvaq()
        {
            return View(new PlasterDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Suvaq(PlasterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Sahe < 0)
            {
                ModelState.AddModelError(string.Empty, "Sahe menfi ola bilmez");
                return View(model);
            }
            if (model.Qalinliq <= 0)
            {
                ModelState.AddModelError(string.Empty, "Qalinliq menfi ve ya sifir ola bilmez");
                return View(model);
            }
            if (model.Qalinliq > 5)
            {
                ModelState.AddModelError(string.Empty, "5 sm-dən çox suvaq məsləhət görülmür");
                return View(model);
            }
            var plaster = await _context.Plasters.FirstOrDefaultAsync();

            if (plaster == null)
            {
                ModelState.AddModelError("", "Məlumat bazasında suvaq üçün məlumat tapılmadı.");
                return View(model);
            }

            // Hesablamalar
            decimal iscininQiymeti = model.Sahe * plaster.WorkerSalaryForArea;
            decimal sementQiymeti = model.Sahe * plaster.CementPrice * 0.2m * model.Qalinliq;
            decimal sementMiqdari = model.Sahe * 0.2m  *model.Qalinliq;
            decimal qumQiymeti = model.Sahe * plaster.SandPrice * model.Qalinliq * 0.025m;
            decimal qumMiqdari = model.Sahe * model.Qalinliq * 0.025m;
            decimal isinhecmi = model.Sahe ;

            // View üçün məlumatları ötürürük
            ViewBag.IscininQiymeti = iscininQiymeti;
            ViewBag.SementQiymeti = sementQiymeti;
            ViewBag.SementMiqdari = sementMiqdari;
            ViewBag.QumQiymeti = qumQiymeti;
            ViewBag.QumMiqdari = qumMiqdari;
            ViewBag.IsinHecmi = isinhecmi;

            return View(model);
        }
    }


}

