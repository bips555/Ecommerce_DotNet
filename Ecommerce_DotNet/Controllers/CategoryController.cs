﻿using Ecommerce_DataAccess.Data;
using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> objectCategoryList = _categoryRepository.GetAll().ToList();
            return View(objectCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name cannot be same as Display Order");
            }
            if (ModelState.IsValid)
            {
               _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
          Category categoryById= _categoryRepository.Get(u=>u.Id==id);
            if ((categoryById == null))
            {
                return NotFound();
            }
            return View(categoryById);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
           
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["success"] = "Category Updated Successfully";
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
            Category categoryById = _categoryRepository.Get(u=>u.Id==id);
            if ((categoryById == null))
            {
                return NotFound();
            }
            return View(categoryById);

           
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category category = _categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");

        }

    }
}
