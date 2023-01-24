using Dashboard.Api.Context;
using Dashboard.Api.ViewModels;
using Dashboard.Api.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IOrderService _orderServiceImplementation;

    public OrderService(AppDbContext context, IOrderService orderServiceImplementation)
    {
        _context = context;
        _orderServiceImplementation = orderServiceImplementation;
    }
    
    public async Task<OrderView> GetOrdersViewAsync(Guid orderId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        if (order is null)
        {
            throw new NotFoundException<Order>();
        }

        return order.Adapt<OrderView>();
    }
}

public class NotFoundException<T> : Exception
{
    public NotFoundException() : base($"Given object {typeof(T).Name} is not found")
    { }
}