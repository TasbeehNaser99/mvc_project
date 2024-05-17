using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
      private readonly ApplicationDbContext context;
         
        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var categories=context.Categories.ToList();
            return View(categories);
        }
    }
}
