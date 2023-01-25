using Dashboard.Api.Context;
using Dashboard.Api.Exceptions;
using Dashboard.Api.ViewModels;
using Dashboard.Api.Entities;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;


[Scoped]
public class OrderService : IOrderService
{
    private readonly AppDbContext _context;


    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrderView> GetOrderByIdAsync(Guid orderId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        if (order is null)
        {
            throw new NotFoundException<Order>();
        }

        return order.Adapt<OrderView>();
    }

    public async Task<List<OrderView>> GetOrdersAsync()
    {
        var orders = await _context.Orders.ToListAsync();
        orders ??= new List<Order>();

        return orders.Select(o => o.Adapt<OrderView>()).ToList();
    }

}

