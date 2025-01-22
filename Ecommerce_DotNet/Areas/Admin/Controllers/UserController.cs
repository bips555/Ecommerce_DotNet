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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
      
        public UserController(ApplicationDbContext context)
        {
           
           _context= context;
        }
        public IActionResult Index()
        {
          
            return View();
        }
       
        #region  APICALLS(AJAX)
        [HttpGet]
        public IActionResult Getall()
        {
            List<ApplicationUser> objUserList = _context.ApplicationUsers.Include(u=>u.Company).ToList();
            var userRoles = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();
            foreach(var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return Json(new { data = objUserList });
        }
        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromdb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if(objFromdb == null)
            {
                return Json(new
                {
                    success = false, message = "Error while Locking/Unlocking"
                });
            }
            if(objFromdb.LockoutEnd!=null && objFromdb.LockoutEnd > DateTime.Now)
          
            {
                objFromdb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromdb.LockoutEnd = DateTime.Now.AddYears(1);
            }
            _context.SaveChanges();
            return Json(new
            {
                success = true,
                message = "Delete Successfull"
            });

        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
           
            return Json(new { success = true, message = "Operation Successfull" });
        }

        #endregion

    }

}
