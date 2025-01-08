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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment )
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objectProductList = _unitOfWork.Product.GetAll().ToList();
           
            return View(objectProductList);
        }
        public IActionResult Upsert(int? id)
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
            if(id == null || id == 0)
            {
                return View(productVM);
            }
          else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
           
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");
                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                    if(productVM.Product.Id == 0 )
                    {
                        _unitOfWork.Product.Add(productVM.Product);
                        TempData["success"] = "Product Added Successfully";
                    }
                    else
                    {
                        _unitOfWork.Product.Update(productVM.Product);
                        TempData["success"] = "Product Updated Successfully";
                    }
                }
               
                _unitOfWork.Save();
                
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
