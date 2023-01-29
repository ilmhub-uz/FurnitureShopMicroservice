using Contract.Api.Dto;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDto createOrder)
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            var orderId = await orderService.CreateOrderAsync(Guid.NewGuid(), createOrder);
            return Ok(orderId);
        }

        [HttpGet("{OrderId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByIdAsync(Guid OrderId)
        {
            return Ok(await orderService.GetOrderByIdAsync(OrderId));
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrder()
        {
            var orders = await orderService.GetOrder();
            return Ok(orders);
        }

        [HttpDelete]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteOrderAsync(Guid orderId)
        {
            await orderService.DeleteOrderAsync(orderId);
            return Ok();
        }
    }
}