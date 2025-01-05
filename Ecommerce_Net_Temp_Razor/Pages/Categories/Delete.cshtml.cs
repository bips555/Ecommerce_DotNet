using Ecommerce_Net_Temp_Razor.Data;
using Ecommerce_Net_Temp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Net_Temp_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _context.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category category = _context.Categories.Find(Category.Id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");

        }

    }
}
