using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CargoDeliveryFront.Models;

namespace RazorPagesApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        DatabaseContext context;
        [BindProperty]
        public Order order { get; set; } = new();
        public CreateModel(DatabaseContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            order.OrderNumber = GenerateOrderNumber();
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        Random rng = new Random();

        public string GenerateOrderNumber()
        {
            long orderPart1 = rng.Next(100000, 9999999);
            int orderPart2 = rng.Next(1000, 9999);
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char firstLetter = letters[rng.Next(letters.Length)];
            char secondLetter = letters[rng.Next(letters.Length)];
            string orderNumber = $"{firstLetter}{secondLetter}-{orderPart1}-{orderPart2}";
            return orderNumber;
        }
    }
}