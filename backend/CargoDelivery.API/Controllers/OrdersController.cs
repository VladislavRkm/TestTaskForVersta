using CargoDelivery.API.Contracts;
using CargoDelivery.Application.Services;
using CargoDelivery.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CargoDelivery.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> GetOrders()
    {
        var orders = await _orderService.GetAllOrders();

        var response = orders.Select(o => new OrderResponse(o.Id, o.OrderNumber, o.SenderCity, o.SenderAddress, o.RecipientCity, o.RecipientAddress, o.Weight, o.PickUpDate));
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrderRequest orderRequest)
    {
        var (order, error) = Order.Create(
            Guid.NewGuid(),
            orderRequest.SenderCity,
            orderRequest.SenderAddress,
            orderRequest.RecipientCity,
            orderRequest.RecipientAddress,
            orderRequest.Weight,
            orderRequest.PickUpDate);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        var orderId = await _orderService.CreateOrder(order);
        return Ok(orderId);
    }
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateOrder(Guid id, [FromBody] OrderRequest orderRequest)
    {
        var orderId = await _orderService.UpdateOrder(id, orderRequest.SenderCity, orderRequest.SenderAddress, orderRequest.RecipientCity, orderRequest.RecipientAddress, orderRequest.Weight, orderRequest.PickUpDate);
        return Ok(orderId);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteOrder(Guid id)
    {
        return Ok(await _orderService.DeleteOrder(id));
    }
}
