using CargoDeliveryFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CargoDeliveryFront.Pages
{
    public class IndexModel : PageModel
    {
        DatabaseContext context;
        public List<Order> Orders { get; private set; } = new();
        public IndexModel(DatabaseContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Orders = context.Orders.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var order = await context.Orders.FindAsync(id);

            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}