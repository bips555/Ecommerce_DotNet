using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Ecommerce_Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace Ecommerce_DotNet.Areas.Admin.Controllers
{
    [Area("admin")] 
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
        public IActionResult Getall(string status)
        {
            IEnumerable<OrderHeader> objectOrderHeader = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            switch (status)
            {
                case "pending":
                    objectOrderHeader = objectOrderHeader.Where(u => u.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    objectOrderHeader = objectOrderHeader.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objectOrderHeader = objectOrderHeader.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objectOrderHeader = objectOrderHeader.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    break;
            }
            return Json(new { data = objectOrderHeader });

           
        }
    }
}
