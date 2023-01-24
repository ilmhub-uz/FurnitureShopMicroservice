using Dashboard.Api.ViewModels;
using Dashboard.Data.Context;
using Dashboard.Data.Entites;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;

public class OrderService : IOrderService
{
    private IOrderService _orderServiceImplementation;
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
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