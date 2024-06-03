using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required")]
        [MaxLength(30,ErrorMessage ="max length must be 30 character")]
        [Remote("CheckName",null,ErrorMessage ="exist")]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
