using System.ComponentModel.DataAnnotations;

namespace tarifuygulaması.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Güvenlik sorusu seçiniz.")]
        public int SecurityQuestionId { get; set; }

        [Required(ErrorMessage = "Güvenlik sorusu cevabı zorunludur.")]
        public string SecurityAnswer { get; set; }
    }
}