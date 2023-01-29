using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;

namespace Contract.Api.Services;

[Scoped]
public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<Guid> CreateOrderAsync(Guid userId, CreateOrderDto createOrder)
    {
        var orderId = Guid.NewGuid();

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Status = EOrderStatus.Created,
            OrderProducts = ConvertToOrderProduct(createOrder, orderId)
        };

        await orderRepository.CreateOrderAsync(order);
        return orderId;
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        await orderRepository.DeleteOrderAsync(order);
    }

    public async Task<List<Order>?> GetOrder()
    {
        var orders = await orderRepository.GetOrders();
        return orders;
    }

    public async Task<Order?> GetOrderByIdAsync(Guid OrderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(OrderId);
        return order;
    }

    public async Task UpdateOrderAsync(Guid orderId, UpdateOrderDto updateOrderDto)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);

        if(updateOrderDto.OrderStatus != null) order.Status = updateOrderDto.OrderStatus.Value;

        await orderRepository.UpdateOrder(order);
    }

    private List<OrderProduct> ConvertToOrderProduct(CreateOrderDto createOrderDto, Guid orderId)
    {
        var orderProductList = new List<OrderProduct>();
        foreach (var orderProduct in createOrderDto.Products)
        {
            orderProductList.Add(new OrderProduct
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = orderProduct.ProductId,
                Count = orderProduct.Count
            });
        }
        return orderProductList;
    }
}