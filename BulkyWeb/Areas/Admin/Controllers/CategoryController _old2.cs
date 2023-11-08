//using Bulky.Data;
//using Bulky.DataAccess.Repository;
//using Bulky.DataAccess.Repository.IRepository;
//using Bulky.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Runtime.CompilerServices;

//namespace Bulky.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly ICategoryRepository _categoryRepository;
//        private readonly IUnitOfWork _unitOfWork;

//        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
//        {
//            _categoryRepository= categoryRepository;
//            _unitOfWork= unitOfWork;
//        }

//        //show all record
//        public IActionResult Index()
//        {
//            return View(_categoryRepository.GetAll().ToList());
//        }

//        //Open empty create page
//        public IActionResult CreateCategory()
//        {
//            return View();
//        }
        
//        //Create new Category
//        [HttpPost]
//        public IActionResult CreateCategory(Category command)
//        {
//            //custom validation
//            var allData = _categoryRepository.GetAll().ToList();

//            var allCategoryNames = allData.Select(c => c.Name).ToList();
//            if (allCategoryNames.Contains(command.Name))
//                ModelState.AddModelError("name", "The Category already exists!");

//            var allCategoryDisplayOrder = allData.Select(c => c.DisplayOrder).ToList();
//            if (allCategoryDisplayOrder.Contains(command.DisplayOrder))
//                ModelState.AddModelError("displayorder", "Please choose different Display Order!");

//            //if error return to current page
//            if (!ModelState.IsValid) return View();

//            _categoryRepository.Insert(command);
//            _unitOfWork.Save();

//            TempData["success"] = "A Category has been created!";

//            //return View();
//            //return RedirectToAction("Index", "category");
//            return RedirectToAction("Index");
//        }

//        //open edit page from category/index
//        public IActionResult EditCategory(Guid? CategoryId)
//        {
//            if (CategoryId == null) return NotFound();
//            var category = _categoryRepository.GetFirstOrDefault(u => u.CategoryId == CategoryId);
//            if (category == null) return NotFound();

//            return View(category);
//        }

//        // Save edited values
//        [HttpPost]
//        public IActionResult EditCategory(Category command)
//        {

//            //custom validation
//            //var allDataExceptCurrentOne = _dbContext.Categories.Where(c => c.CategoryId != command.CategoryId).ToList();
//            var allDataExceptCurrentOne = _categoryRepository.GetAll().Where(c => c.CategoryId != command.CategoryId).ToList();
//            var allCategoryDisplayOrder = allDataExceptCurrentOne.Select(c => c.DisplayOrder).ToList();
//            if (allCategoryDisplayOrder.Contains(command.DisplayOrder))
//            {
//                TempData["error"] = "Same Display Order already exists!";
//                return View();
//            }

//            var allCategoryNames = allDataExceptCurrentOne.Select(c => c.Name).ToList();
//            if (allCategoryNames.Contains(command.Name))
//            {
//                TempData["error"] = "Same Category already exists!";
//                return View();
//            }


//            if (ModelState.IsValid)
//            {
//                //var x = _dbContext.Categories.ToList().Find(c => c.CategoryId == command.CategoryId);
//                var x = _categoryRepository.GetFirstOrDefault(c => c.CategoryId == command.CategoryId);
                    
//                x.Name = command.Name;
//                x.DisplayOrder= command.DisplayOrder;
//                _unitOfWork.Save();
//                TempData["success"] = "Category updated successfully!";
//            }

//            return RedirectToAction("Index");

//        }

//        //Open Delete page
//        public IActionResult DeleteCategory(Guid? CategoryId)
//        {
//            if (CategoryId == null) return NotFound();
//            var category = _categoryRepository.GetFirstOrDefault(c => c.CategoryId == CategoryId);
//            if (category == null) return NotFound();

//            return View(category);
//        }

//        //Delete
//        [HttpPost, ActionName("DeleteCategory")]
//        public IActionResult DeleteCategoryById(Guid? categoryId)
//        {
//            //var foundCategory =  _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
//            var foundCategory = _categoryRepository.GetFirstOrDefault(c => c.CategoryId == categoryId);
//            if (foundCategory == null) return NotFound();

//            _categoryRepository.Remove(foundCategory);
//            _unitOfWork.Save();

//            TempData["success"] = "Category deleted successfully!";


//            return RedirectToAction("Index");
//        }
//    }
//}
