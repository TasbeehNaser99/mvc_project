using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "title of book must be maxmum 50 character ")]
        public string Title { get; set; } = null!;
        [Display(Name ="Author")]
        public int AuthorId { get; set; }

        public List<SelectListItem>? Authors { get; set; }
       public string Publisher { get; set; } = null!;
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }=DateTime.Now;
        [Display(Name = "Image")]
        public IFormFile? ImageUrl { get; set; }
        public string Description { get; set; }
        public List<int> selectedCategories { get; set; }=new List<int>();  
        public List<SelectListItem>? Categories { get; set; }

    }
}
