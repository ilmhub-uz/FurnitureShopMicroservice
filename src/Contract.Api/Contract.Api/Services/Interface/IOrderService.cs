using Contract.Api.Dto;
using Contract.Api.Entities;

namespace Contract.Api.Services.Interface;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(Guid userId,CreateOrderDto createOrder);
    Task DeleteOrderAsync(Guid orderId);
    Task<Order?> GetOrderByIdAsync(Guid OrderId);
    Task<List<Order>?> GetOrder();
    Task UpdateOrderAsync(Guid orderId,UpdateOrderDto updateContractDto);
}