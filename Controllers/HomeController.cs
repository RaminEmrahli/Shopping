using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.DAL;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var category=_context.Categories.FirstOrDefault(x=>x.Id == id);
            if (category is null)
            {
                category = _context.Categories.First();
            }
            var data = _context.Products.Where(x=>x.CategoryId==category.Id).Where(x=>x.StockCount>0).ToList();

            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return View(data);
        }
    }
}
