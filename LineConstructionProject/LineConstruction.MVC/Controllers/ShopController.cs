using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LineConstruction.MVC.Controllers
{
	public class ShopController : Controller
	{
		private readonly IProductService _productService;

		public ShopController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index(string search)
		{
			ICollection<Product> products;

			if (!string.IsNullOrEmpty(search))
			{
				products = await _productService.SearchProductsAsync(search);
			}
			else
			{
				products = await _productService.GetAllAsync();
			}

			return View(products);
		}
	}
}
