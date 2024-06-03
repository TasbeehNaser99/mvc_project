

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public List<BookCategory> Books { get; set; } = new List<BookCategory>();

    }
}
