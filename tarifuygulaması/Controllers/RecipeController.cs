using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarifuygulaması.Data;

namespace tarifuygulaması.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Detail(int id)
        {
            var tarif = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (tarif == null)
                return NotFound();

            return View(tarif);
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            ViewBag.Kategoriler = _context.Categories.ToList();
            return View();
        }
        
        public IActionResult NeYemekYapsam()
        {
            return View();
        }
    }
}