using Ecommerce_DotNet.Data;
using Ecommerce_DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DotNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> objectCategoryList = _context.Categories.ToList();
            return View(objectCategoryList);
        }
    }
}
