using CargoDelivery.Core.Models;

namespace CargoDelivery.Application.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder(Order order);
        Task<Guid> DeleteOrder(Guid id);
        Task<List<Order>> GetAllOrders();
        Task<Guid> UpdateOrder(Guid id, string SenderCity, string SenderAddress, string RecipientCity, string RecipientAddress, float Weight, DateTime PickUpDate);
    }
}