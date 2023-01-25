using Contract.Api.Context;
using Contract.Api.Context.Repositories;
using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Services.Interface;
using JFA.DependencyInjection;

namespace Contract.Api.Services
{
    [Scoped]
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrder)
        {
            await orderRepository.CreateOrderAsync(createOrder);
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            await orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<List<Order>?> GetOrder() => await orderRepository.GetOrder();

        public async Task<Order?> GetOrderByIdAsync(Guid OrderId)
        {
            return await orderRepository.GetOrderByIdAsync(OrderId);
        }
    }
}
