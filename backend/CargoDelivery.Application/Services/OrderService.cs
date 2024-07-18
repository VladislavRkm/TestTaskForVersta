using CargoDelivery.Core.Abstractions;
using CargoDelivery.Core.Models;

namespace CargoDelivery.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<List<Order>> GetAllOrders()
    {
        return await _orderRepository.GetOrders();
    }

    public async Task<Guid> CreateOrder(Order order)
    {
        return await _orderRepository.Create(order);
    }
    public async Task<Guid> UpdateOrder(Guid id, string SenderCity, string SenderAddress, string RecipientCity, string RecipientAddress, float Weight, DateTime PickUpDate)
    {
        return await (_orderRepository.Update(id, SenderCity, SenderAddress, RecipientCity, RecipientAddress, Weight, PickUpDate));
    }
    public async Task<Guid> DeleteOrder(Guid id)
    {
        return await _orderRepository.Delete(id);
    }
}
