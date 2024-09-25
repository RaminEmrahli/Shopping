using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.DAL;
using Shopping.Entities;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;

        public OrderController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CompleteOrder()
        {
            if (HttpContext.Session.GetString("Cart") == null)
            {
                return BadRequest("Basket is null");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CompleteOrder(Order model)
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            ShoppingCartVM vm = JsonConvert.DeserializeObject<ShoppingCartVM>(cartJson);

            foreach (var item in vm.CardItems)
            {
                var newOrder = new Order()
                {
                    EmailAdress = model.EmailAdress,
                    FullName = model.FullName,
                    Phone = model.Phone,
                    Location = model.Location,
                    ProductId = item.Product.Id,
                    Amount = item.Amount,
                    Subtotal = Convert.ToDouble(item.Amount * item.Product.Price)
                };
                Product p = _context.Products.FirstOrDefault(x => x.Id == item.Product.Id);
			    p.StockCount = p.StockCount - item.Amount;
				_context.SaveChanges();
                _context.Orders.Add(newOrder);
            }
            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");
            return RedirectToAction("ShoppingCart", "Basket");
        }
    }
}
