using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModel;

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
            var categories=context.Categories.ToList().Select(category=> new CategoryVM
            {

                Id = category.Id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                UpdatedOn = category.UpdatedOn,
            }).ToList();
          

            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                var viewModel = new CategoryVM
                {
                    Id = id,
                    Name = category.Name,
                    CreatedOn = category.CreatedOn,
                    UpdatedOn = category.UpdatedOn,
                };
                return View(viewModel);
            }
          return NotFound();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM categoryvm )
        {
            if(!ModelState.IsValid)
            {
                 return (View("Create", categoryvm));
            }
            else
            {
                var category=new Category
                {
                    Name = categoryvm.Name,
                };
                try {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }catch
                {
                    ModelState.AddModelError("Name", "category name is already exist");
                    return (View("Create", categoryvm));

                }
               
            }
          
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if(category is null) {
                return NotFound();
            }
            var viewModel=new CategoryVM { Name = category.Name,Id=id };
            return (View("Create",viewModel)); 
        }
        [HttpPost]
        public IActionResult Edit(CategoryVM categoryvm) { 
        
                 if(!ModelState.IsValid)
                 {
                 return (View("Create", categoryvm));
                 }

    var category = context.Categories.Find(categoryvm.Id);
            if (category == null)
            {
                return NotFound();
            }
           category.Name= categoryvm.Name;
            category.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");

               
        }
        public IActionResult Delete(int id)
        {

            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }
        public IActionResult CheckName(CategoryVM categoryvm)
        {
            var isExist=context.Categories.Any(context=>context.Name==categoryvm.Name); 
            return Json(!isExist);
        }
            
    }
  

    }
