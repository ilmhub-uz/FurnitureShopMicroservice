using Contract.Api.Context;
using Contract.Api.Entities;
using Contract.Api.Services.Interface;

namespace Contract.Api.Services;

public class OrderService //: IOrderService
{
    /*private readonly AppDbContext _context;
    private readonly IOrderRepository _orderRepository;

    public OrderService(AppDbContext context, IOrderRepository orderRepository)
    {
        this._context = context;
        this._orderRepository = orderRepository;
    }

    public async Task CreateOrderAsync(Order createOrder)
    {
        var newOrder = new Order()
        {
            Status = EOrderStatus.Created,
            CreatedAt = DateTime.UtcNow,
        };
        var createorder = await _context.Orders.AddAsync(newOrder);

    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var order = await _orderRepository.GetOrderByIdAsync(orderId);

        await _orderRepository.DeleteOrderAsync(order);
    }

    public async Task<List<Order>> GetOrder()
    {
        var order = await _orderRepository.GetOrder();
        return order;
    }

    public async Task<Order?> GetOrderByIdAsync(Guid orderId)
    {

        var order = await _orderRepository.GetOrderByIdAsync(orderId);


        return order;
    }*/
}
