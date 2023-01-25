using Contract.Api.Dto;

namespace Contract.Api.Context.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(CreateOrderDto createOrder);
        Task DeleteOrderAsync(Guid orderId);
        Task<Entities.Order?> GetOrderByIdAsync(Guid OrderId);
        Task<List<Entities.Order>?> GetOrder();
    }
}
