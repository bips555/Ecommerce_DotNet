using System.Diagnostics;
using Ecommerce_DataAccess.Repository.IRepository;
using Ecommerce_Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_DotNet.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;   
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult Details(int id)
        {
            ShoppingCart shoppingCart = new()
            {
                     Product = _unitOfWork.Product.Get(u=>u.Id==id,includeProperties: "Category"),
                Count = 1,
                ProductId = id
            };
          
            return View(shoppingCart);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
