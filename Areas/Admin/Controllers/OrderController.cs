using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.DAL;

namespace Shopping.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize]
	public class OrderController : Controller
	{
		private readonly ApplicationContext _context;
		public OrderController(ApplicationContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var data = _context.Orders.Include(x=>x.Product).ToList();
			return View(data);
		}
	}
}
