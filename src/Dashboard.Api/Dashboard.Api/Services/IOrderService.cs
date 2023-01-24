using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services;

public interface IOrderService
{
    Task<OrderView> GetOrdersViewAsync(Guid orderId);
}