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

            decimal iscininQiymeti = model.Sahe * plaster.WorkerSalaryForArea;
            decimal sementQiymeti = model.Sahe * plaster.CementPrice * 0.2m * model.Qalinliq;
            decimal sementMiqdari = model.Sahe * 0.2m * model.Qalinliq;
            decimal qumQiymeti = model.Sahe * plaster.SandPrice * model.Qalinliq * 0.025m;
            decimal qumMiqdari = model.Sahe * model.Qalinliq * 0.025m;
            decimal isinhecmi = model.Sahe;


            ViewBag.IscininQiymeti = iscininQiymeti;
            ViewBag.SementQiymeti = sementQiymeti;
            ViewBag.SementMiqdari = sementMiqdari;
            ViewBag.QumQiymeti = qumQiymeti;
            ViewBag.QumMiqdari = qumMiqdari;
            ViewBag.IsinHecmi = isinhecmi;

            return View(model);
        }
        public IActionResult Bunovre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bunovre(decimal OuterPerimetr, decimal OuterTrenchWidth, decimal OuterTrenchDepth,
                                     decimal InternalPerimetr, decimal InternalTrenchWidth, decimal InternalTrenchDepth)
        {
            if (OuterPerimetr<0 || OuterTrenchDepth<0 || OuterTrenchWidth<0 || InternalPerimetr<0 || InternalTrenchDepth<0 || InternalTrenchWidth<0)
            {
                ModelState.AddModelError(string.Empty, "Ölçüləri düzgün daxil edin. Uzunluq mənfi ola bilməz");
                return View();
            }
            decimal betonHecmi = Math.Round(
     (OuterPerimetr * 0.01m * OuterTrenchWidth * 0.01m * OuterTrenchDepth) +
     (InternalPerimetr * 0.01m * InternalTrenchWidth * 0.01m * InternalTrenchDepth),  2  );

            decimal armaturHecmi = Math.Round( (OuterPerimetr) + (InternalPerimetr), 2 );
            decimal xamitHecmi = Math.Round(armaturHecmi * 3, 0, MidpointRounding.AwayFromZero);

            decimal karkazHecmi = Math.Round((OuterPerimetr) + (InternalPerimetr), 2);
            decimal betonIsHecmi = Math.Round((OuterPerimetr) + (InternalPerimetr), 2);


            var foundation = _context.Foundations.FirstOrDefault();

            decimal betonQiymeti = foundation != null
            ? Math.Round(betonHecmi * foundation.ConcretePrice, 2)
          : 0;

            decimal qazmaHecmi = Math.Round(
   (OuterPerimetr * 0.01m * OuterTrenchWidth * 0.01m * OuterTrenchDepth) +
   (InternalPerimetr * 0.01m * InternalTrenchWidth * 0.01m * InternalTrenchDepth), 2);


            decimal armaturQiymeti = foundation != null
  ? Math.Round(armaturHecmi * foundation.ArmaturePrice, 2)
  : 0;

            decimal betonIsQiymeti = foundation != null
  ? Math.Round(betonIsHecmi * foundation.ConcretePriceEmployer, 2)
  : 0;

            decimal karkazQiymeti = foundation != null
? Math.Round(karkazHecmi * foundation.KhamitPriceEmployer, 2)
: 0;
            decimal xamitQiymeti = foundation != null
? Math.Round(xamitHecmi * foundation.KhamitPrice, 2)
: 0;

            decimal qazmaQiymeti = foundation != null
? Math.Round(qazmaHecmi * foundation.DrillingPriceEmployer, 2)
: 0;

       
            ViewBag.ArmaturHecmi = armaturHecmi;
            ViewBag.BetonHecmi = betonHecmi;
            ViewBag.BetonQiymeti = betonQiymeti;
            ViewBag.ArmaturQiymeti = armaturQiymeti;
            ViewBag.XamitQiymeti = xamitQiymeti;
            ViewBag.XamitHecmi = xamitHecmi;
            ViewBag.QazmaHecmi = qazmaHecmi;
            ViewBag.QazmaQiymeti = qazmaQiymeti;
            ViewBag.KarkazQiymeti = karkazQiymeti;
            ViewBag.KarkazHecmi = karkazHecmi;
            ViewBag.BetonIsHecmi = betonIsHecmi;
            ViewBag.BetonIsQiymeti = betonIsQiymeti;

            return View();
        }




        public IActionResult Horgu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Horgu(MasonryDTO masonryDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Boş input qoymaq olmaz");
                return View(masonryDTO);
            }

            decimal totalWallArea = masonryDTO.LengthWalls * masonryDTO.HeightWalls;
                decimal totalDoorArea = masonryDTO.CountDoors * masonryDTO.WidthDoors * masonryDTO.HeightDoors * 0.01m * 0.01m;
                decimal totalWindowArea = masonryDTO.CountWindows * masonryDTO.WidthWindows * masonryDTO.HeightWindows * 0.01m * 0.01m;
                decimal netWallArea = (totalWallArea - totalDoorArea - totalWindowArea);
            if (netWallArea<=0)
            {
                ModelState.AddModelError(string.Empty, "Sahe menfi ola bilmez, Ölçüleri düzgün daxil edin");
                return View(masonryDTO);

            }
            decimal countStoneSingle = Math.Ceiling(netWallArea * 12.5m);
                decimal countStonePlural = Math.Ceiling(netWallArea * 12.5m);

                decimal countCementSingle = Math.Ceiling(countStoneSingle * 0.0125m);
                decimal countCementPlural = Math.Ceiling(countStonePlural * 0.0250m);
                decimal countSandSingle = countCementSingle * 0.25m;
                decimal countSandPlural = countCementPlural * 0.5m;
            
                var masonry = _context.Masonries.FirstOrDefault();
                if (masonry != null)
                {
                    decimal countStoneSinglePrice = Math.Ceiling(countStoneSingle * masonry.StonePrice);
                    decimal countStonePluralPrice = Math.Ceiling(countStonePlural * masonry.StonePrice);
                    decimal countCementSinglePrice = Math.Ceiling(countCementSingle * masonry.CementPrice);
                    decimal countCementPluralPrice = Math.Ceiling(countCementPlural * masonry.CementPrice);
                    decimal totalEmployerSingle = Math.Ceiling(netWallArea * masonry.WorkerSalary);
                    decimal totalEmployerPlural = Math.Ceiling(netWallArea * masonry.WorkerSalary * 2);
                    decimal sandSinglePrice = Math.Ceiling(countSandSingle * masonry.SandPrice);
                    decimal sandPluralPrice = Math.Ceiling(countSandPlural * masonry.SandPrice);

                    ViewBag.TotalEmployerSingle = totalEmployerSingle;
                    ViewBag.TotalEmployerPlural = totalEmployerPlural;
                    ViewBag.NetWallArea = netWallArea;

                    ViewBag.CountStoneSingle = countStoneSingle;
                    ViewBag.CountStonePlural = countStonePlural;
                    ViewBag.CountStoneSinglePrice = countStoneSinglePrice;
                    ViewBag.CountStonePluralPrice = countStonePluralPrice;

                    ViewBag.CountCementPluralPrice = countCementPluralPrice;
                    ViewBag.CountCementSinglePrice = countCementSinglePrice;
                    ViewBag.CountCementSingle = countCementSingle;
                    ViewBag.CountCementPlural = countCementPlural;

                    ViewBag.CountSandPlural = countSandPlural;
                    ViewBag.CountSandSingle = countSandSingle;
                    ViewBag.SandSinglePrice = sandSinglePrice;
                    ViewBag.SandPluralPrice = sandPluralPrice;
                }
            
            return View(masonryDTO);
        }

        public IActionResult Dam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dam(RoofDTO roofDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Boş input qoymaq olmaz");
                return View(roofDTO);
            }
            if (roofDTO.LengthHouse < 0 || roofDTO.WidthHouse < 0 || roofDTO.RoofHeight < 0)
            {
                ModelState.AddModelError(string.Empty, "Uzunluq menfi ola bilmez");
                return View(roofDTO);
            }
            var roof = _context.Roofs.FirstOrDefault();
            decimal evSahesi = roofDTO.LengthHouse * roofDTO.WidthHouse;
            decimal damSahesi = evSahesi + (2 * (roofDTO.LengthHouse * roofDTO.RoofHeight));
            decimal siferSahesi = 2 * roofDTO.LengthHouse * roofDTO.RoofHeight;
            decimal siferQiymet = Math.Round(siferSahesi * roof.RoofingPrice, 0, MidpointRounding.AwayFromZero);
            decimal dampol = evSahesi;
            decimal dampolqiymet = Math.Round(dampol * roof.WoodPrice, 0, MidpointRounding.AwayFromZero);
            decimal reykaMiqdar = Math.Round(damSahesi * 1.5m, 0, MidpointRounding.AwayFromZero);
            decimal yivQutu = Math.Round(damSahesi / 10, 0, MidpointRounding.AwayFromZero);

            decimal reykaQiymet = Math.Round(reykaMiqdar * roof.ReykaPrice, 0, MidpointRounding.AwayFromZero);
            decimal yivQiymet = Math.Round(yivQutu * roof.NailPrice, 0, MidpointRounding.AwayFromZero);
            decimal damQurulmaQiymet = Math.Round(damSahesi * roof.WorkerSalaryForArea, 0, MidpointRounding.AwayFromZero);
            ViewBag.Dampol = dampol;
            ViewBag.DampolQiymet = dampolqiymet;
            ViewBag.SiferSahesi = siferSahesi;
            ViewBag.SiferQiymet = siferQiymet;
            ViewBag.DamSahesi = damSahesi;
            ViewBag.ReykaMiqdar = reykaMiqdar;
            ViewBag.YivQutu = yivQutu;
            ViewBag.ReykaQiymet = reykaQiymet;
            ViewBag.YivQiymet = yivQiymet;
            ViewBag.DamQurulmaQiymet = damQurulmaQiymet;
            return View(roofDTO);
        }
    }
}