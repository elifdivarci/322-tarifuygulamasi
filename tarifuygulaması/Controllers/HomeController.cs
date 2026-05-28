using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarifuygulaması.Data;

namespace tarifuygulaması.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kategoriler = await _context.Categories
                .Include(c => c.Recipes)
                .ToListAsync();
            
            foreach (var kategori in kategoriler)
            {
                kategori.Recipes = kategori.Recipes.Take(4).ToList();
            }

            return View(kategoriler);
        }
    }
}