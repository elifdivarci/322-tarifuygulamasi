using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarifuygulaması.Data;

namespace tarifuygulaması.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            var kategori = await _context.Categories
                .Include(c => c.Recipes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (kategori == null)
                return NotFound();

            return View(kategori);
        }
    }
}