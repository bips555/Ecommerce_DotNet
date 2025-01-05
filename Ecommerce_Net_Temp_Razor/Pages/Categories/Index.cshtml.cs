using Ecommerce_Net_Temp_Razor.Data;
using Ecommerce_Net_Temp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Net_Temp_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
       public List<Category> CategoryList { get; set; }
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }
    }
}
