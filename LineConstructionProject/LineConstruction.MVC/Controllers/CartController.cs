using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.ViewModels;
using LineConstruction.Core.Entities;
using LineConstruction.Core.Enums;
using LineConstruction.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Threading.Tasks;

namespace LineConstruction.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            BasketDto basket = GetBasket();
            ViewBag.TotalPrice = basket.Items.Sum(item => item.NewPrice * item.Quantity);
            return View(basket);
        }
        public IActionResult Checkout()
        {
            if (!User.Identity.IsAuthenticated)
            {
              return  RedirectToAction("Login", "Account");
            }
            BasketDto basket = GetBasket();
            if (basket == null || !basket.Items.Any())
            {
                return BadRequest("Səbət boşdur");
            }
            var checkoutVM = new CheckoutVM
            {
                Basket = basket,
                Checkout = new CheckoutDTO()
            };

            ViewBag.TotalPrice = basket.Items.Sum(item => item.NewPrice * item.Quantity);
            return View(checkoutVM);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutVM checkoutViewModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (checkoutViewModel.Checkout.Adress == null)
            {
                ModelState.AddModelError("Checkout.Adress", "Adresi daxil edin");
                return View(checkoutViewModel);
            }
           
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound("İstifadəçi tapılmadı");

            BasketDto basket = GetBasket();
            if (basket == null || !basket.Items.Any()) return BadRequest("Səbət boşdur");

            // STRIPE Checkout Session Yaratmaq
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = basket.Items.Select(item => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Title,
                        },
                        UnitAmount = (long)(item.NewPrice * 100),
                    },
                    Quantity = item.Quantity,
                }).ToList(),
                Mode = "payment",
                SuccessUrl = Url.Action("OrderSuccess", "Cart", new { orderId = Guid.NewGuid() }, Request.Scheme),
                CancelUrl = Url.Action("Checkout", "Cart", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);

            
            var orderCheckout = new OrderCheckout
            {
                Adress = checkoutViewModel.Checkout.Adress,
                OrderStatus = OrderStatus.Pending,
                BasketItems = basket.Items.Select(item => new BasketItem
                {
                    ProductId = item.Id,
                    Price = item.NewPrice,
                    UserId = user.Id,
                    Count = item.Quantity
                }).ToList(),
                CreateAt = DateTime.UtcNow
            };

            await _context.OrderCheckouts.AddAsync(orderCheckout);
            await _context.SaveChangesAsync();

            
            Response.Cookies.Delete("Basket");

            return Redirect(session.Url);
        }


       

        public IActionResult OrderSuccess(Guid orderId)
        {
            Response.Cookies.Delete("Basket");
            ViewBag.OrderId = orderId;
            return View();
        }


       

        public async Task<IActionResult> AddToBasket(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    return NotFound("tapilmadi");
                }
                Core.Entities.Product? productt = await _context.Products.FindAsync(productId);
                if (productt == null)
                {
                    return NotFound("tapilmadi");
                }
                BasketItem? basketItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.ProductId == productId && b.UserId == user.Id);
                if (basketItem == null)
                {
                    BasketItem item = new BasketItem();
                    item.ProductId = productt.Id;
                    item.Price = productt.NewPrice;
                    item.UserId = user.Id;
                    item.Count = 1;
                    await _context.BasketItems.AddAsync(item);
                }
                else
                {
                    basketItem.Count++;
                }
                await _context.SaveChangesAsync();
            }

            if (productId == 0)
            {
                return NotFound("tapilmadi");
            }

            Core.Entities.Product? product = _context.Products.Find(productId);
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




            return RedirectToAction("Index", "Shop");
        }
        public BasketDto GetBasket()
        {
            var basketCookie = Request.Cookies["Basket"];

            if (basketCookie == null)
            {
                Console.WriteLine("Basket cookie tapılmadı!");
                return new BasketDto { Items = new List<BasketItemDto>() }; 
            }

            try
            {
                var basket = JsonConvert.DeserializeObject<BasketDto>(basketCookie);
                if (basket == null)
                {
                    Console.WriteLine("Basket deserialization null qaytardı!");
                    return new BasketDto { Items = new List<BasketItemDto>() };
                }

                if (basket.Items == null)
                {
                    Console.WriteLine("Basket.Items null-dır!");
                    basket.Items = new List<BasketItemDto>();
                }

                return basket;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Basket deserialization xətası: {ex.Message}");
                return new BasketDto { Items = new List<BasketItemDto>() };
            }
        }


        [HttpPost]
        public IActionResult RemoveFromBasket(int productId)
        {
            var basket = GetBasket();
            if (basket == null || basket.Items.Count == 0)
            {
                return NotFound("Basket boşdur və ya tapılmadı.");
            }

            var itemToRemove = basket.Items.FirstOrDefault(g => g.Id == productId);
            if (itemToRemove != null)
            {
                basket.Items.Remove(itemToRemove);
                var cookieOption = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true
                };
                var cookieBasket = JsonConvert.SerializeObject(basket);
                Response.Cookies.Append("Basket", cookieBasket, cookieOption);
                return Ok();
            }

            return NotFound("Məhsul tapılmadı.");
        }
        [HttpPost]
        public IActionResult IncreaseQuantity(int productId)
        {
            var basket = GetBasket();
            var item = basket.Items.FirstOrDefault(g => g.Id == productId);
            if (item != null)
            {
                item.Quantity++;
                SaveBasket(basket);
                return Json(new { success = true, quantity = item.Quantity, totalPrice = basket.Items.Sum(i => i.NewPrice * i.Quantity), itemTotal = item.Quantity * item.NewPrice });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int productId)
        {
            var basket = GetBasket();
            var item = basket.Items.FirstOrDefault(g => g.Id == productId);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
                SaveBasket(basket);
                return Json(new { success = true, quantity = item.Quantity, totalPrice = basket.Items.Sum(i => i.NewPrice * i.Quantity), itemTotal = item.Quantity * item.NewPrice });
            }
            return Json(new { success = false });
        }

        private void SaveBasket(BasketDto basket)
        {
            var cookieOption = new CookieOptions { Expires = DateTime.Now.AddDays(7), HttpOnly = true };
            Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket), cookieOption);
        }

    }
}
