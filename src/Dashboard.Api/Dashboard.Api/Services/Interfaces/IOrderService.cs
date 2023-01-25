using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services;

public interface IOrderService
{
    Task<OrderView> GetOrderByIdAsync(Guid orderId);
    Task<List<OrderView>> GetOrdersAsync();
}