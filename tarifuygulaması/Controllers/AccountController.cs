using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using tarifuygulaması.Data;
using tarifuygulaması.Models;

namespace tarifuygulaması.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Register()
        {
            ViewBag.Sorular = new SelectList(_context.SecurityQuestions, "Id", "Soru");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sorular = new SelectList(_context.SecurityQuestions, "Id", "Soru");
                return View(model);
            }
            
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Bu email zaten kayıtlı.");
                ViewBag.Sorular = new SelectList(_context.SecurityQuestions, "Id", "Soru");
                return View(model);
            }

            var user = new User
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Email = model.Email,
                SifreHash = HashSifre(model.Sifre),
                SecurityQuestionId = model.SecurityQuestionId,
                SecurityAnswer = model.SecurityAnswer.Trim().ToLower()
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.Ad + " " + user.Soyad);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login");

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            var user = await _context.Users
                .Include(u => u.Recipes)
                .ThenInclude(r => r.Category)
                .Include(u => u.Favorites)
                .ThenInclude(f => f.Recipe)
                .ThenInclude(r => r.Category)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.Users
                .Include(u => u.SecurityQuestion)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı.");
                return View(model);
            }
            
            if (user.BasarisizGirisSayisi >= 3)
            {
                TempData["UserId"] = user.Id;
                TempData["Soru"] = user.SecurityQuestion.Soru;
                return RedirectToAction("GuvenlikSorusu");
            }

            if (user.SifreHash != HashSifre(model.Sifre))
            {
                user.BasarisizGirisSayisi++;
                await _context.SaveChangesAsync();

                int kalan = 3 - user.BasarisizGirisSayisi;
                if (kalan <= 0)
                {
                    TempData["UserId"] = user.Id;
                    TempData["Soru"] = user.SecurityQuestion.Soru;
                    return RedirectToAction("GuvenlikSorusu");
                }

                ModelState.AddModelError("", $"Şifre hatalı. {kalan} hakkınız kaldı.");
                return View(model);
            }
            
            user.BasarisizGirisSayisi = 0;
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.Ad + " " + user.Soyad);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult GuvenlikSorusu()
        {
            if (TempData["Soru"] == null)
                return RedirectToAction("Login");

            ViewBag.Soru = TempData["Soru"];
            ViewBag.UserId = TempData["UserId"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuvenlikSorusu(int userId, string cevap)
        {
            var user = await _context.Users
                .Include(u => u.SecurityQuestion)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return RedirectToAction("Login");

            if (user.SecurityAnswer == cevap.Trim().ToLower())
            {
                user.BasarisizGirisSayisi = 0;
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", user.Ad + " " + user.Soyad);
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Cevap yanlış, tekrar deneyin.";
            ViewBag.Soru = user.SecurityQuestion.Soru;
            ViewBag.UserId = userId;
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        private string HashSifre(string sifre)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sifre));
            return Convert.ToBase64String(bytes);
        }
    }
}