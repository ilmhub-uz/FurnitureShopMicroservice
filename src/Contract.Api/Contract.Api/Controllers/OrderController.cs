using Contract.Api.Dto;
using Contract.Api.Entities;
using Contract.Api.Services;
using Contract.Api.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDto createOrder)
        {
            await orderService.CreateOrderAsync(createOrder);
            
            return Ok();
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderByIdAsync(Guid OrderId)
        {
            return Ok(await orderService.GetOrderByIdAsync(OrderId));
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrder() => Ok(await orderService.GetOrder());

        [HttpDelete]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteOrderAsync(Guid orderId)
        {
            await orderService.DeleteOrderAsync(orderId);

            return Ok();
        }
    }
}
