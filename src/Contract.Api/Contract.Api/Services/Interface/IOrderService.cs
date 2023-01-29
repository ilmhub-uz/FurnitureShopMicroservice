using Contract.Api.Dto;

namespace Contract.Api.Services.Interface
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(Guid userId,CreateOrderDto createOrder);
        Task DeleteOrderAsync(Guid orderId);
        Task<Entities.Order?> GetOrderByIdAsync(Guid OrderId);
        Task<List<Entities.Order>?> GetOrder();
    }
}
