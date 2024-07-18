using Microsoft.EntityFrameworkCore;
using CargoDeliveryFront.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DatabaseContext)));
    });

builder.Services.AddRazorPages();

AppContext.SetSwitch(switchName: "Npgsql.EnableLegacyTimestampBehavior",
                     true);

var app = builder.Build();

app.MapRazorPages();

app.Run();