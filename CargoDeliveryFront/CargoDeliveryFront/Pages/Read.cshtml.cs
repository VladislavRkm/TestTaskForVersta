using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CargoDeliveryFront.Models;

namespace RazorPagesApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class ReadModel : PageModel
    {
        DatabaseContext context;
        [BindProperty]
        public Order? order { get; set; }

        public ReadModel(DatabaseContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            order = await context.Orders.FindAsync(id);

            if (order == null) return NotFound();

            return Page();

        }
        
    }
}