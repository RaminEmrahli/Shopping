using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shopping.DAL;
using Shopping.Entities;
using Shopping.Models;

namespace Shopping.Service
{
    public class _LayoutService
    {
        private readonly ApplicationContext _context;
        public _LayoutService(ApplicationContext context)
        {
            _context=context;
        }
        public List<Category> GetCategories()
        {
			return _context.Categories.Include(x=>x.Products).ToList();
        }
    }
}
