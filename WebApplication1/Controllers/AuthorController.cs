using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext context;
        public AuthorController(ApplicationDbContext context) {
            this.context = context;
        }

        public IActionResult Index()
        {
            var Authors=context.Authors.ToList().Select(author=>new AuthorVM
            {
                Id = author.Id,
                Name = author.Name,
                CreatedOn = author.CreatedOn,
                UpdatedOn = author.UpdatedOn,
            }).ToList();
            return View(Authors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }
        [HttpPost]
        public IActionResult Create(AuthorFormVM authorvm)
        {
            if (!ModelState.IsValid)
            {
                return (View("Form", authorvm));
            }
            else
            {
                var author = new Author
                {
                    Name = authorvm.Name,
                };
                try
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("Name", "author name is already exist");
                    return (View("Form", authorvm));

                }

            }


        }

        public IActionResult Details(int id)
        {
            var author = context.Authors.Find(id);
            if (author != null)
            {
                var viewModel = new AuthorVM
                {
                    Id = id,
                    Name = author.Name,
                    CreatedOn = author.CreatedOn,
                    UpdatedOn = author.UpdatedOn,
                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            if (author is null)
            {
                return NotFound();
            }
            var viewModel = new AuthorVM { Name = author.Name, Id = id };
            return (View("Form", viewModel));
        }
        [HttpPost]
        public IActionResult Edit(AuthorVM authorvm)
        {

            if (!ModelState.IsValid)
            {
                return (View("Create", authorvm));
            }

            var author = context.Authors.Find(authorvm.Id);
            if (author == null)
            {
                return NotFound();
            }
            author.Name = authorvm.Name;
            author.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {

            var author = context.Authors.Find(id);
            if (author is null)
            {
                return NotFound();
            }
            context.Authors.Remove(author);
            context.SaveChanges();
            return Ok();
        }
    }
}
