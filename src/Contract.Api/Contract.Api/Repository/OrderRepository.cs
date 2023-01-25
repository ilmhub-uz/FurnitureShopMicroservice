using Contract.Api.Context;
using Contract.Api.Entities;
using Contract.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateOrderAsync(Order createOrder)
        {
            await context.Orders.AddAsync(createOrder);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order deleteOrder)
        {
            context.Orders.Remove(deleteOrder);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>?> GetOrder()
        {
            var order = await context.Orders.ToListAsync();
            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid OrderId)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == OrderId);
            return order;
        }
    }
}
