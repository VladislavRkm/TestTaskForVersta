using CargoDelivery.Core.Models;

namespace CargoDelivery.Core.Abstractions;

public interface IOrderRepository
{
    Task<Guid> Create(Order order);
    Task<Guid> Delete(Guid id);
    Task<List<Order>> GetOrders();
    Task<Guid> Update(Guid id, string SenderCity, string SenderAddress, string RecipientCity, string RecipientAddress, float Weight, DateTime PickUpDate);

}
