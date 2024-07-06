using CargoDelivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace CargoDelivery.DataAccess;

public class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
}
