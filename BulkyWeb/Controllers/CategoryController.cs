using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categoryList =  _dbContext.Categories.ToList(); //select * from Category
            return View(categoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category command)
        {
            //custom validation
            var allData = _dbContext.Categories.ToList();

            var allCategoryNames = allData.Select(c => c.Name).ToList();
            if (allCategoryNames.Contains(command.Name))
                ModelState.AddModelError("name", "The Category already exists!");

            var allCategoryDisplayOrder = allData.Select(c => c.DisplayOrder).ToList();
            if (allCategoryDisplayOrder.Contains(command.DisplayOrder))
                ModelState.AddModelError("displayorder", "Please choose different Display Order!");

            //if error return to current page
            if (!ModelState.IsValid) return View();

            _dbContext.Categories.Add(command); 
            _dbContext.SaveChanges();
            TempData["success"] = "A Category has been created!";

            //return View();
            //return RedirectToAction("Index", "category");
            return RedirectToAction("Index");
        }

        //open edit page from category/index
        public IActionResult EditCategory(int? CategoryId)
        {
            if (CategoryId == null || CategoryId == 0) return NotFound();
            var category = _dbContext.Categories.Find(CategoryId);
            if (category == null) return NotFound();

            return View(category);
        }

        // Edit
        [HttpPost]
        public IActionResult EditCategory(Category command)
        {
            if (ModelState.IsValid)

            _dbContext.Categories.Update(command);
            _dbContext.SaveChanges();
            TempData["success"] = "Category updated successfully!";


            return RedirectToAction("Index");

        }

        //Open Delete page
        public IActionResult DeleteCategory(int? CategoryId)
        {
            if (CategoryId == null || CategoryId == 0) return NotFound();
            var category = _dbContext.Categories.Find(CategoryId);
            if (category == null) return NotFound();

            return View(category);
        }

        //Delete
        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryById(int? categoryId)
        {
            var foundCategory =  _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (foundCategory == null) return NotFound();

            _dbContext.Categories.Remove(foundCategory);
            _dbContext.SaveChanges();

            TempData["success"] = "Category deleted successfully!";


            return RedirectToAction("Index");
        }
    }
}
