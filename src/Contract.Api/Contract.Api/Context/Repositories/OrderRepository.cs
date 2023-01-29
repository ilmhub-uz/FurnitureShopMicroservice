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
    public class OrderRepository : IOrderRepository, IsEntityExistRepository
    {

        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)    
        {
            context.Orders!.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>?> GetOrders()
        {
            var orders = await context.Orders!.Include(order =>order.OrderProducts).ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(Guid OrderId)
        {
            var order = await context.Orders!.Include(order => order.OrderProducts).FirstAsync(o => o.Id == OrderId);
            return order;
        }
        public async Task UpdateOrder(Order order)
        {
            context.Orders!.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsEntityExist(Guid orderId)
        {
            if (await context.Orders!.AnyAsync(c => c.Id == orderId)) return true;
            else return false;
        }
    }
}
