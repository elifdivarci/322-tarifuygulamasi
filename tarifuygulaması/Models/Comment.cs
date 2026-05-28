namespace tarifuygulaması.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public int RecipeId { get; set; }
        public int UserId { get; set; }

        public Recipe Recipe { get; set; }
        public User User { get; set; }
    }
}