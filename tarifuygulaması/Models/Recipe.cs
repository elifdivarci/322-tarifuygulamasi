namespace tarifuygulaması.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string GorselUrl { get; set; }
        public int HazirlamaSuresi { get; set; } 
        public int PisirmeSuresi { get; set; }    
        public int KisiSayisi { get; set; }
        public int CategoryId { get; set; }
        public int? UserId { get; set; }        

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}