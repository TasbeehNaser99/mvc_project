namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
}
