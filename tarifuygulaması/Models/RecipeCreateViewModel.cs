using System.ComponentModel.DataAnnotations;

namespace tarifuygulaması.Models
{
    public class RecipeCreateViewModel
    {
        [Required(ErrorMessage = "Tarif adı zorunludur.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Hazırlama süresi zorunludur.")]
        [Range(0, 300, ErrorMessage = "0-300 dakika arası giriniz.")]
        public int HazirlamaSuresi { get; set; }

        [Required(ErrorMessage = "Pişirme süresi zorunludur.")]
        [Range(0, 300, ErrorMessage = "0-300 dakika arası giriniz.")]
        public int PisirmeSuresi { get; set; }

        [Required(ErrorMessage = "Kişi sayısı zorunludur.")]
        [Range(1, 20, ErrorMessage = "1-20 kişi arası giriniz.")]
        public int KisiSayisi { get; set; }

        public IFormFile? Gorsel { get; set; }
        
        public List<string> MalzemeAd { get; set; } = new();
        public List<string> MalzemeMiktar { get; set; } = new();
    }
}