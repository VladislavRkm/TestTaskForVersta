using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CargoDeliveryFront.Models;

namespace RazorPagesApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        DatabaseContext context;
        [BindProperty]
        public Order? order { get; set; }

        public EditModel(DatabaseContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            order = await context.Orders.FindAsync(id);

            if (order == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Orders.Update(order!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}