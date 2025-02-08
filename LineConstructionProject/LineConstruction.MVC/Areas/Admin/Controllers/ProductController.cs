using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICatagoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICatagoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Product> products = await _productService.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelsate is not Valid");
                ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");

                return View(productCreateDTO);
            }
            ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");

            await _productService.CreateAsync(productCreateDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Product product = await _productService.GetByIdAsync(id);
                ProductUpdateDTO productUpdateDTO = _mapper.Map<ProductUpdateDTO>(product);
                ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");
                return View(productUpdateDTO);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");
                return View(productUpdateDTO);
            }
            try
            {
                await _productService.UpdateAsync(productUpdateDTO);
                ViewBag.Catagory = new SelectList(await _categoryService.GetAllAsync(), "Id", "Title");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _productService.SoftDeleteAsync(id);
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
                Product product = await _productService.GetByIdAsync(id);
                return View(product);
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
				await _productService.RestoreAsync(id);
				return RedirectToAction("Index");
			}
			catch
			{
				return RedirectToAction("Error");

			}
		}
		public async Task<IActionResult> Recycle()
		{
			ICollection<Product> product = await _productService.GetAllDeletedAsync();
			return View(product);
		}
	}
}
