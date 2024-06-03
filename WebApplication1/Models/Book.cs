using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "title of book must be maxmum 50 character ")]
        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }

        public Author? Author { get; set; }
        public string Publisher { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public List<BookCategory> Categories { get; set;} = new List<BookCategory>();

    }
}
