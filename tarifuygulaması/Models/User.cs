namespace tarifuygulaması.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string SifreHash { get; set; }
        public int SecurityQuestionId { get; set; }
        public string SecurityAnswer { get; set; }
        public int BasarisizGirisSayisi { get; set; } = 0;

        public SecurityQuestion SecurityQuestion { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}