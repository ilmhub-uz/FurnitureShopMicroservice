using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Exceptions;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Contract.Api.Context.Repositories
{
    [Scoped]
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateOrderAsync(CreateOrderDto createOrder)
        {
            var product = createOrder.Adapt<Entities.Order>();
            await context.Orders.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid orderId)    
        {
            if (!await context.Orders.AnyAsync(c => c.Id == orderId))
            {
                throw new NotFoundException<Entities.Order>();
            }

            var order = await context.Orders.FirstAsync(c => c.Id == orderId);

            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>?> GetOrder()
        {
            var query = await context.Orders.ToListAsync();

            return query.Select(c => c.Adapt<Entities.Order>()).ToList();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid OrderId)
        {
            if (!await context.Orders.AnyAsync(c => c.Id == OrderId))
            {
                throw new NotFoundException<Entities.Contract>();
            }
            var product = await context.Orders.FirstAsync(c => c.Id == OrderId);
            return product.Adapt<Entities.Order>();
        }
    }
}
