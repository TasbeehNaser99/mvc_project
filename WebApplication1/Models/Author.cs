using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "max length must be 30 character")]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
