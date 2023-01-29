using Contract.Api.Entities;

namespace Contract.Api.Context.Repositories;

public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    Task DeleteOrderAsync(Order order);
    Task<Order> GetOrderByIdAsync(Guid OrderId);
    Task<List<Order>?> GetOrders();
    Task UpdateOrder (Order order);
}