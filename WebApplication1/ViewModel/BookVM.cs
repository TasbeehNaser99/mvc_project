using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
     
        public string Author { get; set; }=null!;

     
        public string Publisher { get; set; } = null!;
 
        public DateTime PublishDate { get; set; }
   
        public string ImageUrl { get; set; }
    
        public List<string> Categories { get; set; }
       

    }
}
