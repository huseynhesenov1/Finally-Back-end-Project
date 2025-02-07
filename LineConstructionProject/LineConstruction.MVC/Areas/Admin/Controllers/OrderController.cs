using AutoMapper;
using LineConstruction.BLa.DTOs;
using LineConstruction.BLa.Services.Abstractions;
using LineConstruction.BLa.Services.Implementations;
using LineConstruction.Core.Entities;
using LineConstruction.DAL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IOurServiceService _ourServiceService;
		private readonly IOurTeamService _ourTeamService;
		private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper,  IOurServiceService ourServiceService, IOurTeamService ourTeamService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _ourServiceService = ourServiceService;
            _ourTeamService = ourTeamService;
        }

        public async Task<IActionResult> Index()
		{
			ICollection<Order> order = await _orderService.GetAllAsync();
			return View(order);
		}
		public async Task<IActionResult> Recycle()
		{
			ICollection<Order> order = await _orderService.GetAllDeletedAsync();
			return View(order);
		}
		public async Task<IActionResult> SoftDelete(int id)
		{
			try
			{
				await _orderService.SoftDeleteAsync(id);
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
				Order order = await _orderService.GetByIdAsync(id);
				OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
                ViewBag.OurServices = new SelectList( await _ourServiceService.GetAllAsync(), "Id", "Title");
				ViewBag.OurTeams = new SelectList(await _ourTeamService.GetAllAsync(), "Id", "FullName");
				return View(orderDTO);
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");
			}

		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, OrderDTO orderDTO)
		{
			try
			{
				await _orderService.UpdateAsync(id, orderDTO);
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
				Order order = await _orderService.GetByIdAsync(id);
				return View(order);
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
				await _orderService.RestoreAsync(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");

			}
		}
	}
}
