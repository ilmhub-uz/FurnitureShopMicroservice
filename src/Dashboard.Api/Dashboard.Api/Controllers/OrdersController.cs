using Dashboard.Api.Services;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
[Scoped]
public class OrdersController : Controller
{
    private readonly OrderService _service;

    public OrdersController(OrderService orderService) => _service = orderService;
    
    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        return Ok();
    }
}