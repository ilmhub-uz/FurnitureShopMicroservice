namespace Contract.Api.Repository.Interface
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Entities.Order createOrder);
        Task DeleteOrderAsync(Entities.Order deleteOrder);
        Task<Entities.Order?> GetOrderByIdAsync(Guid OrderId);
        Task<List<Entities.Order>?> GetOrder();
    }
}
