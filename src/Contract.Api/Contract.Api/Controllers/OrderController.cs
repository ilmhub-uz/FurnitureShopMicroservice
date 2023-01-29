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

        [HttpGet("{orderId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByIdAsync(Guid orderId)
        {
            return Ok(await orderService.GetOrderByIdAsync(orderId));
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrder()
        {
            var orders = await orderService.GetOrder();
            return Ok(orders);
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteOrderAsync(Guid orderId)
        {
            await orderService.DeleteOrderAsync(orderId);
            return Ok();
        }

        [HttpPut("{orderId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateOrderAsync(Guid orderId ,UpdateOrderDto updateOrderDto)
        {
            await orderService.UpdateOrderAsync(orderId, updateOrderDto);
            return Ok();
        }
    }
}