using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Cart.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly IDistributedCache _distributedCache;

    public CartsController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct()
    {
        await _distributedCache.SetStringAsync("key", "value");

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        return Ok(await _distributedCache.GetStringAsync("key"));
    }
}