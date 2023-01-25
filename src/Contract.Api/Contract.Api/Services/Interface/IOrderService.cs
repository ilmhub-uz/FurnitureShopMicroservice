using Contract.Api.Dto;
using Contract.Api.ViewModel;

namespace Contract.Api.Services.Interface
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto createOrder);
        Task DeleteOrderAsync(Guid orderId);
        Task<Entities.Order?> GetOrderByIdAsync(Guid OrderId);
        Task<List<Entities.Order>?> GetOrder();
    }
}
