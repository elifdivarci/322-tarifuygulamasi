using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarifuygulaması.Data;
using tarifuygulaması.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                .Include(r => r.User)
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

            ViewBag.Kategoriler = new SelectList(_context.Categories, "Id", "Ad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateViewModel model)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                ViewBag.Kategoriler = new SelectList(_context.Categories, "Id", "Ad");
                return View(model);
            }
            
            string gorselUrl = "/images/meal.jpeg";
            if (model.Gorsel != null && model.Gorsel.Length > 0)
            {
                var uzanti = Path.GetExtension(model.Gorsel.FileName);
                var dosyaAdi = Guid.NewGuid().ToString() + uzanti;
                var kayitYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dosyaAdi);

                using (var stream = new FileStream(kayitYolu, FileMode.Create))
                {
                    await model.Gorsel.CopyToAsync(stream);
                }
                gorselUrl = "/images/" + dosyaAdi;
            }

            var tarif = new Recipe
            {
                Ad = model.Ad,
                Aciklama = model.Aciklama,
                CategoryId = model.CategoryId,
                HazirlamaSuresi = model.HazirlamaSuresi,
                PisirmeSuresi = model.PisirmeSuresi,
                KisiSayisi = model.KisiSayisi,
                GorselUrl = gorselUrl,
                UserId = HttpContext.Session.GetInt32("UserId")
            };

            _context.Recipes.Add(tarif);
            await _context.SaveChangesAsync();
            
            for (int i = 0; i < model.MalzemeAd.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(model.MalzemeAd[i]))
                {
                    _context.Ingredients.Add(new Ingredient
                    {
                        Ad = model.MalzemeAd[i].Trim(),
                        Miktar = i < model.MalzemeMiktar.Count ? model.MalzemeMiktar[i].Trim() : "",
                        RecipeId = tarif.Id
                    });
                }
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = tarif.Id });
        }
        
        public IActionResult NeYemekYapsam()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> YorumSil(int yorumId, int recipeId)
        {
            var yorum = await _context.Comments.FindAsync(yorumId);

            if (yorum != null && yorum.UserId == HttpContext.Session.GetInt32("UserId"))
            {
                _context.Comments.Remove(yorum);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detail", new { id = recipeId });
        }
        
        
        [HttpPost]
        public async Task<IActionResult> TarifSil(int id)
        {
            var tarif = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Comments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (tarif == null)
                return NotFound();
            
            if (tarif.UserId != HttpContext.Session.GetInt32("UserId"))
                return Unauthorized();

            _context.Ingredients.RemoveRange(tarif.Ingredients);
            _context.Comments.RemoveRange(tarif.Comments);
            _context.Recipes.Remove(tarif);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", "Account");
        }
    }
}