using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CargoDeliveryFront.Models;

public class DatabaseContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
