using LineConstruction.BLa.DTOs;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LineConstruction.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BasketDto basket = GetBasket();
            return View(basket);
        }
        public IActionResult AddToBasket(int productId)
        {
            Product? product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound("tapilmadi");
            }
            var cookieOption = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            BasketDto basket = GetBasket();

            if (basket == null)
            {
                basket = new BasketDto();
            }
            BasketItemDto? existingBasketItem = basket.Items.FirstOrDefault(g => g.Id == product.Id);
            if (existingBasketItem == null)
            {

                BasketItemDto basketItemDto = new BasketItemDto()
                {
                    Description = product.Description,
                    ImagePath = product.ImagePath,
                    Id = product.Id,
                    Title = product.Title,
                    OldPrice = product.OldPrice,
                    NewPrice = product.NewPrice,
                    CatagoryId = product.CatagoryId,
                    Quantity = 1
                };
                basket.Items.Add(basketItemDto);
            }
            else
            {
                existingBasketItem.Quantity += 1;

            }

            var cookieBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", cookieBasket, cookieOption);


            return Ok();
        }
        public BasketDto GetBasket()
        {
            var basket = Request.Cookies["Basket"];
            if (basket != null)
            {
                BasketDto? existingBasket = JsonConvert.DeserializeObject<BasketDto>(basket);
                return existingBasket;

            }
            return null;
        }
    }
}
