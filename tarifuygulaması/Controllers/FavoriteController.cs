using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarifuygulaması.Data;
using tarifuygulaması.Models;

namespace tarifuygulaması.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly AppDbContext _context;

        public FavoriteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int recipeId, string returnUrl = "/")
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            var mevcut = await _context.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.RecipeId == recipeId);

            if (mevcut != null)
                _context.Favorites.Remove(mevcut);
            else
                _context.Favorites.Add(new Favorite { UserId = userId, RecipeId = recipeId });

            await _context.SaveChangesAsync();

            return Redirect(returnUrl);
        }
    }
}