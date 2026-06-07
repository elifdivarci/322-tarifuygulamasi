namespace tarifuygulaması.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}