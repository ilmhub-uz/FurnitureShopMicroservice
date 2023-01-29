using Contract.Api.Context;
using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.VisualBasic;
using System.Collections.Generic;

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
            OrderProducts = ConvertToOrderProdcut(createOrder)
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
        return await orderRepository.GetOrderByIdAsync(OrderId);
    }

    private List<OrderProduct>ConvertToOrderProdcut (CreateOrderDto createOrderDto)
    {
        var orderProductList = new List<OrderProduct>();
        foreach (var orderProduct in createOrderDto.Products)
        {
            orderProductList.Add(new OrderProduct
            {
                Id = Guid.NewGuid(),
                ProductId = orderProduct.ProductId,
                Count = orderProduct.Count
            });
        }
        return orderProductList;
    }
}