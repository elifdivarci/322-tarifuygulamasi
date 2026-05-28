namespace tarifuygulaması.Models
{
    public class SecurityQuestion
    {
        public int Id { get; set; }
        public string Soru { get; set; }
        public ICollection<User> Users { get; set; }
    }
}