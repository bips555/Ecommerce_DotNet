using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_DotNet.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
