using Ecommerce_DataAccess.Data;
using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Ecommerce_Models.ViewModels;
using Ecommerce_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
      
        public CompanyController(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objectCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objectCompanyList);
        }
        public IActionResult Upsert(int? id)
        {
        
           
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(u => u.Id==id);
                return View(company);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid) { 
            
                if (company.Id == 0)
                    {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
            _unitOfWork.Save();
            TempData["Success"] = "Company Saved Successfully";
            return RedirectToAction("Index");
                }
            else{
                return View(company);
             }

         }
           





        #region  APICALLS(AJAX)
        [HttpGet]
        public IActionResult Getall()
        {
            List<Company> objectCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objectCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
          
           _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfull" });
        }

        #endregion

    }

}
