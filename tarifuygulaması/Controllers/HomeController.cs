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

            var favoriIdler = new List<int>();
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                int userId = (int)HttpContext.Session.GetInt32("UserId");
                favoriIdler = await _context.Favorites
                    .Where(f => f.UserId == userId)
                    .Select(f => f.RecipeId)
                    .ToListAsync();
            }

            ViewBag.FavoriIdler = favoriIdler;
            return View(kategoriler);
        }
        
    }
}