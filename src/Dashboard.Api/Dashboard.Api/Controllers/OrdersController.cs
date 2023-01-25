using Dashboard.Api.Services;
using Dashboard.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(typeof(OrderView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(OrderView), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        return Ok(order);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<OrderView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.GetOrdersAsync();
        return Ok(orders);
    }
}