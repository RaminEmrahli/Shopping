using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.DAL;
using Shopping.Entities;

namespace Shopping.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize]
	public class CategoryController : Controller
	{
        private readonly ApplicationContext _context;

        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Categories.ToList();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == model.Id);
            category.Name = model.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Categories.FirstOrDefault(x=>x.Id==id);
            _context.Categories.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
