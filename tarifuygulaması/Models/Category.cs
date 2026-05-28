namespace tarifuygulaması.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}