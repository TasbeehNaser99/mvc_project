using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment )
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        

        public IActionResult Index()
        {
            var books = context.Books.Include(book => book.Author)
                                    .Include(book => book.Categories)
                                    .ThenInclude(book => book.Category).ToList().Select(book => new BookVM
                                    {
                                        Id = book.Id,
                                        Title = book.Title,
                                        Author = book.Author.Name,
                                        PublishDate = book.PublishDate,
                                        Publisher = book.Publisher,
                                        ImageUrl = book.ImageUrl,
                                        Categories = book.Categories.Select(book=>book.Category.Name).ToList(),
                                    }).ToList();

        

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authors = context.Authors
                .OrderBy(author => author.Name)
                .Select(author => new SelectListItem
                {
                    Value = author.Id.ToString(),
                    Text = author.Name
                })
                .ToList();

            var categories = context.Categories
                .OrderBy(category => category.Name)
                .Select(category => new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                })
                .ToList();

            var viewModel = new BookFormVM
            {
                Authors = authors,
                Categories = categories,
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(BookFormVM bookFormVM)
        {
            if(!ModelState.IsValid)
            {
                  return View(bookFormVM);
            }
            string ImageName = null;
            if (bookFormVM.ImageUrl != null) {
                ImageName = Path.GetFileName(bookFormVM.ImageUrl.FileName);
                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/img/books", ImageName); 
                var stream=System.IO.File.Create(path);
                bookFormVM.ImageUrl.CopyTo(stream);
            }
            var book = new Book
            {
                Title = bookFormVM.Title,
                AuthorId = bookFormVM.AuthorId,
                PublishDate = bookFormVM.PublishDate,
                Publisher = bookFormVM.Publisher,
                Description = bookFormVM.Description,
                ImageUrl = ImageName,
                Categories = bookFormVM.selectedCategories.Select(id => new BookCategory
                {
                    CategoryId = id,
                }).ToList(),

            };
            context.Books.Add(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
