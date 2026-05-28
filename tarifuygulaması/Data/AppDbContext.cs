using tarifuygulaması.Models;
using Microsoft.EntityFrameworkCore;

namespace tarifuygulaması.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityQuestion>().HasData(
                new SecurityQuestion { Id = 1, Soru = "İlk evcil hayvanınızın adı neydi?" },
                new SecurityQuestion { Id = 2, Soru = "Annenizin kızlık soyadı nedir?" },
                new SecurityQuestion { Id = 3, Soru = "İlk öğretmeninizin adı neydi?" },
                new SecurityQuestion { Id = 4, Soru = "Doğduğunuz şehir neresidir?" },
                new SecurityQuestion { Id = 5, Soru = "Çocukken en sevdiğiniz yemek neydi?" }
            );
            
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Ad = "Tatlılar" },
                new Category { Id = 2, Ad = "Çorbalar" },
                new Category { Id = 3, Ad = "Etli Yemekler" },
                new Category { Id = 4, Ad = "Mezeler" }
            );
            
            modelBuilder.Entity<Recipe>().HasData(
             
                new Recipe
                {
                    Id = 1, Ad = "Vişneli Brownie", Aciklama = "Yoğun çikolata ve vişne aromasıyla nefis bir tatlı.",
                    GorselUrl = "/images/visnelibrowie.jpg", HazirlamaSuresi = 20, PisirmeSuresi = 35, KisiSayisi = 6,
                    CategoryId = 1, UserId = null
                },
                new Recipe
                {
                    Id = 2, Ad = "Sütlaç", Aciklama = "Fırında pişirilmiş geleneksel Türk tatlısı.",
                    GorselUrl = "/images/sutlac.jpeg", HazirlamaSuresi = 15, PisirmeSuresi = 30, KisiSayisi = 4,
                    CategoryId = 1, UserId = null
                },
                new Recipe
                {
                    Id = 3, Ad = "Kazandibi", Aciklama = "Hafif yanık aromalı yumuşak sütlü tatlı.",
                    GorselUrl = "/images/kazandibi.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 25, KisiSayisi = 4,
                    CategoryId = 1, UserId = null
                },
                new Recipe
                {
                    Id = 4, Ad = "Künefe", Aciklama = "Kadayıf ve peynirle yapılan sıcak tatlı.",
                    GorselUrl = "/images/kunefe.webp", HazirlamaSuresi = 15, PisirmeSuresi = 20, KisiSayisi = 2,
                    CategoryId = 1, UserId = null
                },
        
                new Recipe
                {
                    Id = 5, Ad = "Mercimek Çorbası", Aciklama = "Klasik Türk mutfağının vazgeçilmezi.",
                    GorselUrl = "/images/mercimek-corba.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 30, KisiSayisi = 4,
                    CategoryId = 2, UserId = null
                },
                new Recipe
                {
                    Id = 6, Ad = "Domates Çorbası", Aciklama = "Taze domateslerle yapılan hafif çorba.",
                    GorselUrl = "/images/domates-corba.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 25, KisiSayisi = 4,
                    CategoryId = 2, UserId = null
                },
                new Recipe
                {
                    Id = 7, Ad = "Ezogelin Çorbası", Aciklama = "Kırmızı mercimek ve bulgurla dolu lezzetli çorba.",
                    GorselUrl = "/images/ezogelin.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 30, KisiSayisi = 6,
                    CategoryId = 2, UserId = null
                },
                new Recipe
                {
                    Id = 8, Ad = "Yayla Çorbası", Aciklama = "Yoğurtlu pirinçli geleneksel çorba.",
                    GorselUrl = "/images/yayla.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 20, KisiSayisi = 4,
                    CategoryId = 2, UserId = null
                },
    
                new Recipe
                {
                    Id = 9, Ad = "Karnıyarık", Aciklama = "Patlıcan içine kıymalı dolgu ile klasik lezzet.",
                    GorselUrl = "/images/karnıyarık.jpeg", HazirlamaSuresi = 20, PisirmeSuresi = 40, KisiSayisi = 4,
                    CategoryId = 3, UserId = null
                },
                new Recipe
                {
                    Id = 10, Ad = "Etli Güveç", Aciklama = "Sebzeler ve et ile pişirilen fırın yemeği.",
                    GorselUrl = "/images/guvec.jpeg", HazirlamaSuresi = 20, PisirmeSuresi = 60, KisiSayisi = 4,
                    CategoryId = 3, UserId = null
                },
                new Recipe
                {
                    Id = 11, Ad = "İskender Kebap", Aciklama = "Yoğurt ve tereyağlı soslu dürüm kebabı.",
                    GorselUrl = "/images/iskender.jpeg", HazirlamaSuresi = 15, PisirmeSuresi = 30, KisiSayisi = 2,
                    CategoryId = 3, UserId = null
                },
                new Recipe
                {
                    Id = 12, Ad = "Hünkar Beğendi", Aciklama = "Közlenmiş patlıcan püresi üstünde et.",
                    GorselUrl = "/images/huunkar.jpeg", HazirlamaSuresi = 25, PisirmeSuresi = 45, KisiSayisi = 4,
                    CategoryId = 3, UserId = null
                },
              
                new Recipe
                {
                    Id = 13, Ad = "Haydari", Aciklama = "Yoğurt ve sarımsaklı nefis bir meze.",
                    GorselUrl = "/images/haydari.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 0, KisiSayisi = 4,
                    CategoryId = 4, UserId = null
                },
                new Recipe
                {
                    Id = 14, Ad = "Acılı Ezme", Aciklama = "Biber ve domates ile hazırlanan baharatlı meze.",
                    GorselUrl = "/images/ezme.jpeg", HazirlamaSuresi = 15, PisirmeSuresi = 0, KisiSayisi = 4,
                    CategoryId = 4, UserId = null
                },
                new Recipe
                {
                    Id = 15, Ad = "Patlıcan Salatası", Aciklama = "Közlenmiş patlıcanla yapılan soğuk meze.",
                    GorselUrl = "/images/patlicansalatasi.jpeg", HazirlamaSuresi = 20, PisirmeSuresi = 15, KisiSayisi = 4,
                    CategoryId = 4, UserId = null
                },
                new Recipe
                {
                    Id = 16, Ad = "Tarama", Aciklama = "Balık yumurtası ile hazırlanan deniz mezesi.",
                    GorselUrl = "/images/tarama.jpeg", HazirlamaSuresi = 10, PisirmeSuresi = 0, KisiSayisi = 4,
                    CategoryId = 4, UserId = null
                }
            );
           
            modelBuilder.Entity<Ingredient>().HasData(
               
                new Ingredient { Id=1, Ad="Tereyağı", Miktar="125 gr", RecipeId=1 },
                new Ingredient { Id=2, Ad="Bitter Çikolata", Miktar="100 gr", RecipeId=1 },
                new Ingredient { Id=3, Ad="Yumurta", Miktar="2 adet", RecipeId=1 },
                new Ingredient { Id=4, Ad="Şeker", Miktar="1 su bardağı", RecipeId=1 },
                new Ingredient { Id=5, Ad="Un", Miktar="2 su bardağı", RecipeId=1 },
                new Ingredient { Id=6, Ad="Vişne", Miktar="1 su bardağı", RecipeId=1 },

                
                new Ingredient { Id=7, Ad="Süt", Miktar="1 litre", RecipeId=2 },
                new Ingredient { Id=8, Ad="Pirinç", Miktar="2 su bardağı", RecipeId=2 },
                new Ingredient { Id=9, Ad="Şeker", Miktar="1 su bardağı", RecipeId=2 },
                new Ingredient { Id=10, Ad="Nişasta", Miktar="2 yemek kaşığı", RecipeId=2 },

          
                new Ingredient { Id=11, Ad="Süt", Miktar="1 litre", RecipeId=3 },
                new Ingredient { Id=12, Ad="Şeker", Miktar="1 su bardağı", RecipeId=3 },
                new Ingredient { Id=13, Ad="Nişasta", Miktar="3 yemek kaşığı", RecipeId=3 },
                new Ingredient { Id=14, Ad="Un", Miktar="1 yemek kaşığı", RecipeId=3 },

             
                new Ingredient { Id=15, Ad="Kadayıf", Miktar="250 gr", RecipeId=4 },
                new Ingredient { Id=16, Ad="Peynir", Miktar="200 gr", RecipeId=4 },
                new Ingredient { Id=17, Ad="Tereyağı", Miktar="100 gr", RecipeId=4 },
                new Ingredient { Id=18, Ad="Şeker", Miktar="1 su bardağı", RecipeId=4 },
                new Ingredient { Id=19, Ad="Su", Miktar="1 su bardağı", RecipeId=4 },

              
                new Ingredient { Id=20, Ad="Kırmızı Mercimek", Miktar="1.5 su bardağı", RecipeId=5 },
                new Ingredient { Id=21, Ad="Soğan", Miktar="1 adet", RecipeId=5 },
                new Ingredient { Id=22, Ad="Havuç", Miktar="1 adet", RecipeId=5 },
                new Ingredient { Id=23, Ad="Tereyağı", Miktar="2 yemek kaşığı", RecipeId=5 },
                new Ingredient { Id=24, Ad="Tuz", Miktar="1 tatlı kaşığı", RecipeId=5 },

                
                new Ingredient { Id=25, Ad="Domates", Miktar="4 adet", RecipeId=6 },
                new Ingredient { Id=26, Ad="Soğan", Miktar="1 adet", RecipeId=6 },
                new Ingredient { Id=27, Ad="Tereyağı", Miktar="2 yemek kaşığı", RecipeId=6 },
                new Ingredient { Id=28, Ad="Un", Miktar="1 yemek kaşığı", RecipeId=6 },
                new Ingredient { Id=29, Ad="Süt", Miktar="1 su bardağı", RecipeId=6 },

                
                new Ingredient { Id=30, Ad="Kırmızı Mercimek", Miktar="1 su bardağı", RecipeId=7 },
                new Ingredient { Id=31, Ad="Bulgur", Miktar="1 su bardağı", RecipeId=7 },
                new Ingredient { Id=32, Ad="Soğan", Miktar="1 adet", RecipeId=7 },
                new Ingredient { Id=33, Ad="Domates Salçası", Miktar="1 yemek kaşığı", RecipeId=7 },
                new Ingredient { Id=34, Ad="Nane", Miktar="1 tatlı kaşığı", RecipeId=7 },

             
                new Ingredient { Id=35, Ad="Yoğurt", Miktar="2 su bardağı", RecipeId=8 },
                new Ingredient { Id=36, Ad="Pirinç", Miktar="1 su bardağı", RecipeId=8 },
                new Ingredient { Id=37, Ad="Yumurta", Miktar="1 adet", RecipeId=8 },
                new Ingredient { Id=38, Ad="Nane", Miktar="1 tatlı kaşığı", RecipeId=8 },
                new Ingredient { Id=39, Ad="Tereyağı", Miktar="1 yemek kaşığı", RecipeId=8 },

                
                new Ingredient { Id=40, Ad="Patlıcan", Miktar="4 adet", RecipeId=9 },
                new Ingredient { Id=41, Ad="Kıyma", Miktar="250 gr", RecipeId=9 },
                new Ingredient { Id=42, Ad="Soğan", Miktar="1 adet", RecipeId=9 },
                new Ingredient { Id=43, Ad="Domates", Miktar="2 adet", RecipeId=9 },
                new Ingredient { Id=44, Ad="Biber", Miktar="2 adet", RecipeId=9 },

               
                new Ingredient { Id=45, Ad="Dana Eti", Miktar="500 gr", RecipeId=10 },
                new Ingredient { Id=46, Ad="Patates", Miktar="3 adet", RecipeId=10 },
                new Ingredient { Id=47, Ad="Havuç", Miktar="2 adet", RecipeId=10 },
                new Ingredient { Id=48, Ad="Soğan", Miktar="1 adet", RecipeId=10 },
                new Ingredient { Id=49, Ad="Domates Salçası", Miktar="2 yemek kaşığı", RecipeId=10 },

             
                new Ingredient { Id=50, Ad="Dana Eti", Miktar="300 gr", RecipeId=11 },
                new Ingredient { Id=51, Ad="Yoğurt", Miktar="1 su bardağı", RecipeId=11 },
                new Ingredient { Id=52, Ad="Tereyağı", Miktar="50 gr", RecipeId=11 },
                new Ingredient { Id=53, Ad="Domates Salçası", Miktar="1 yemek kaşığı", RecipeId=11 },
                new Ingredient { Id=54, Ad="Pide", Miktar="2 adet", RecipeId=11 },

              
                new Ingredient { Id=55, Ad="Dana Eti", Miktar="400 gr", RecipeId=12 },
                new Ingredient { Id=56, Ad="Patlıcan", Miktar="3 adet", RecipeId=12 },
                new Ingredient { Id=57, Ad="Süt", Miktar="1 su bardağı", RecipeId=12 },
                new Ingredient { Id=58, Ad="Tereyağı", Miktar="2 yemek kaşığı", RecipeId=12 },
                new Ingredient { Id=59, Ad="Un", Miktar="2 yemek kaşığı", RecipeId=12 },

                
                new Ingredient { Id=60, Ad="Süzme Yoğurt", Miktar="2 su bardağı", RecipeId=13 },
                new Ingredient { Id=61, Ad="Sarımsak", Miktar="2 diş", RecipeId=13 },
                new Ingredient { Id=62, Ad="Nane", Miktar="1 tatlı kaşığı", RecipeId=13 },
                new Ingredient { Id=63, Ad="Zeytinyağı", Miktar="1 yemek kaşığı", RecipeId=13 },

                
                new Ingredient { Id=64, Ad="Domates", Miktar="3 adet", RecipeId=14 },
                new Ingredient { Id=65, Ad="Biber", Miktar="3 adet", RecipeId=14 },
                new Ingredient { Id=66, Ad="Soğan", Miktar="1 adet", RecipeId=14 },
                new Ingredient { Id=67, Ad="Maydanoz", Miktar="1 demet", RecipeId=14 },
                new Ingredient { Id=68, Ad="Zeytinyağı", Miktar="2 yemek kaşığı", RecipeId=14 },

                
                new Ingredient { Id=69, Ad="Patlıcan", Miktar="3 adet", RecipeId=15 },
                new Ingredient { Id=70, Ad="Sarımsak", Miktar="2 diş", RecipeId=15 },
                new Ingredient { Id=71, Ad="Zeytinyağı", Miktar="2 yemek kaşığı", RecipeId=15 },
                new Ingredient { Id=72, Ad="Limon", Miktar="1 adet", RecipeId=15 },

             
                new Ingredient { Id=73, Ad="Balık Yumurtası", Miktar="100 gr", RecipeId=16 },
                new Ingredient { Id=74, Ad="Zeytinyağı", Miktar="1 su bardağı", RecipeId=16 },
                new Ingredient { Id=75, Ad="Limon", Miktar="1 adet", RecipeId=16 },
                new Ingredient { Id=76, Ad="Bayat Ekmek", Miktar="2 dilim", RecipeId=16 }
            );
               
        }
    }
}