namespace tarifuygulaması.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Miktar { get; set; } 
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}