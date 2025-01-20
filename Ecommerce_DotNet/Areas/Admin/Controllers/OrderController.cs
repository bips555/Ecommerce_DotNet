using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_DotNet.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Getall()
        {
            List<OrderHeader> objectOrderHeader = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objectOrderHeader });
        }
    }
}
