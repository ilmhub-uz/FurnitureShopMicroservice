using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CartApi.Controllers;

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
        await _distributedCache.SetStringAsync("key", "1, 2, 3", 
            new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var cart = await _distributedCache.GetStringAsync("product");

        return Ok(cart);
    }
}