using Ecommerce_DataAccess.Data;
using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Ecommerce_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objectProductList = _unitOfWork.Product.GetAll().ToList();
           
            return View(objectProductList);
        }
        public IActionResult Create()
        {
            // ViewBag.CategoryList = CategoryList;
            //  ViewData["CategoryList"] = CategoryList;
            ProductVM productVM = new()
            {
                 Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u =>

               new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               })
            };
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u =>

                    new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                
                return View(productVM);
            }
          
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductById = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductById == null)
            {
                return NotFound();
            }
            return View(ProductById);
        }
        [HttpPost]
        public IActionResult Edit(Product Product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductById = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductById == null)
            {
                return NotFound();
            }
            return View(ProductById);


        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product Product = _unitOfWork.Product.Get(u => u.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";

            return RedirectToAction("Index");

        }

    }
}
