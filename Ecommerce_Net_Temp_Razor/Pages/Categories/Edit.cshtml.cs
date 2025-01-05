using Ecommerce_Net_Temp_Razor.Data;
using Ecommerce_Net_Temp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Net_Temp_Razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if( id !=null && id != 0)
            {
                Category = _context.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
