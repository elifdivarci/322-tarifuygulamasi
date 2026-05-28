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
                .Include(r => r.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (tarif == null)
                return NotFound();

            return View(tarif);
        }

        [HttpPost]
        public async Task<IActionResult> YorumEkle(int recipeId, string icerik)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            if (!string.IsNullOrWhiteSpace(icerik))
            {
                var yorum = new tarifuygulaması.Models.Comment
                {
                    RecipeId = recipeId,
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Icerik = icerik.Trim(),
                    OlusturulmaTarihi = DateTime.Now
                };
                _context.Comments.Add(yorum);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detail", new { id = recipeId });
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