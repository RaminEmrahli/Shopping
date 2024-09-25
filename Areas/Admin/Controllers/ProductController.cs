using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.Entities;

namespace Shopping.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Products.Include(x=>x.Category).ToList();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Brand= model.Brand;
            product.Features = model.Features;
            product.StockCount= model.StockCount;
            product.ReleaseDate= model.ReleaseDate; 
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            List<Category> categories = new List<Category>();
            categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            Product product = new Product()
            {
                ImageUrl = model.File.FileName,
                Name = model.Name,
                Price= model.Price,
                Brand = model.Brand,
                Features= model.Features,
                StockCount= model.StockCount,
                ReleaseDate= model.ReleaseDate,
                CategoryId= model.CategoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return View(data);
        }
    }
}
