using Bulky.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //show all record
        public IActionResult Index()
        {
            var allProductList = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(allProductList);
        }

        //Open empty create page
        public IActionResult CreateProduct()
        {
            //set up dropdown data for Category
            IEnumerable<SelectListItem> categoryList =
                  _unitOfWork.CategoryRepository.GetAll()
                  .Select(c => new SelectListItem
                  {
                      Text = c.Name,
                      Value = c.CategoryId.ToString()
                  }
                  );
            //ViewBag.CategoryList = categoryList;
            //ViewData["CategoryList"] = categoryList;

            ProductVM productVM = new ProductVM 
            {
                CategoryList= categoryList,
                Product = new Product()
            };
            return View(productVM);
        }

        //Create new Product
        [HttpPost]
        public IActionResult CreateProduct(ProductVM command)
        {
            //custom validation
            var allData = _unitOfWork.ProductRepository.GetAll().ToList();
            if(allData.Any(b => b.ISBN == command.Product.ISBN))
                ModelState.AddModelError("ISBN", "The ISBN already exists!");

            //if error return to current page with existing data
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> categoryList =
                 _unitOfWork.CategoryRepository.GetAll()
                 .Select(c => new SelectListItem
                 {
                     Text = c.Name,
                     Value = c.CategoryId.ToString()
                 }
                 );
                command.CategoryList = categoryList;
                return View(command);
            }


            _unitOfWork.ProductRepository.Insert(command.Product);
            _unitOfWork.Save();

            TempData["success"] = "A Product has been created!";

            return RedirectToAction("Index");
        }

        //open edit page from category/index
        public IActionResult EditProduct(Guid? ProductId)
        {
            if (ProductId == null) return NotFound();
            var product = _unitOfWork.ProductRepository.GetFirstOrDefault(u => u.ProductId == ProductId);
            if (product == null) return NotFound();

            return View(product);
        }

        // Save edited values
        [HttpPost]
        public IActionResult EditProduct(Product command)
        {

            //custom validation
            //var allDataExceptCurrentOne = _dbContext.Categories.Where(c => c.CategoryId != command.CategoryId).ToList();
            var allDataExceptCurrentOne = _unitOfWork.ProductRepository.GetAll().Where(c => c.ProductId != command.ProductId).ToList();

            var allProductISBNs = allDataExceptCurrentOne.Select(c => c.ISBN).ToList();
            if (allProductISBNs.Contains(command.ISBN))
            {
                TempData["error"] = "Same ISBN already exists!";
                return View();
            }


            if (ModelState.IsValid)
            {
                var x = _unitOfWork.ProductRepository.GetFirstOrDefault(c => c.ProductId == command.ProductId);

                x.Author= command.Author;
                x.Title= command.Title;
                x.Description= command.Description;
                x.ISBN  = command.ISBN;
                x.Price= command.Price;
                x.Price50= command.Price50;
                x.Price100= command.Price100;

                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
            }

            return RedirectToAction("Index");

        }

        //Open Delete page
        public IActionResult DeleteProduct(Guid? ProductId)
        {
            if (ProductId == null) return NotFound();
            var product = _unitOfWork.ProductRepository.GetFirstOrDefault(c => c.ProductId == ProductId);
            if (product == null) return NotFound();

            return View(product);
        }

        //Delete
        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProductById(Guid? ProductId)
        {
            var foundProduct = _unitOfWork.ProductRepository.GetFirstOrDefault(c => c.ProductId == ProductId);
            if (foundProduct == null) return NotFound();

            _unitOfWork.ProductRepository.Remove(foundProduct);
            _unitOfWork.Save();

            TempData["success"] = "Product deleted successfully!";


            return RedirectToAction("Index");
        }
    }
}
