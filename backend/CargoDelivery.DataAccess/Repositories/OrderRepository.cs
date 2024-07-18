using CargoDelivery.Core.Abstractions;
using CargoDelivery.Core.Models;
using CargoDelivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace CargoDelivery.DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DatabaseContext _context;
    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<List<Order>> GetOrders()
    {
        var orderEntities = await _context.Orders.AsNoTracking().ToListAsync();
        var orders = orderEntities
            .Select(o => Order.Create(o.Id, o.SenderCity, o.SenderAddress, o.RecipientCity, o.RecipientAddress, o.Weight, o.PickUpDate).Order)
            .ToList();
        return orders;
    }
    public async Task<Guid> Create(Order order)
    {
        var orderEntity = new OrderEntity()
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            SenderCity = order.SenderCity,
            SenderAddress = order.SenderAddress,
            RecipientCity = order.RecipientCity,
            RecipientAddress = order.RecipientAddress,
            Weight = order.Weight,
            PickUpDate = order.PickUpDate,
        };
    
        await _context.Orders.AddAsync(orderEntity);
        await _context.SaveChangesAsync();
        
        return orderEntity.Id;
    }
    public async Task<Guid> Update(Guid id, string SenderCity, string SenderAddress, string RecipientCity, string RecipientAddress, float Weight, DateTime PickUpDate)
    {
        await _context.Orders.Where(o => o.Id == id).ExecuteUpdateAsync(u => u
        .SetProperty(o => o.SenderCity, o => SenderCity)
        .SetProperty(o => o.SenderAddress, o => SenderAddress)
        .SetProperty(o => o.RecipientCity, o => RecipientCity)
        .SetProperty(o => o.RecipientAddress, o => RecipientAddress)
        .SetProperty(o => o.Weight, o => Weight)
        .SetProperty(o => o.PickUpDate, o => PickUpDate));
        
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Orders.Where(b => b.Id == id).ExecuteDeleteAsync();

        return id;
    }
}
