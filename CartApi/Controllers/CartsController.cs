using CartApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
    public async Task<IActionResult> AddProductToCart([FromBody] AddToCartDto addToCartDto)
    {
        var cacheKey = addToCartDto.UserId.ToString();
        string cacheValue;

        var productsJson = await _distributedCache.GetStringAsync(cacheKey);

        if (productsJson == null)
        {
            cacheValue = JsonConvert.SerializeObject(new List<string>() { addToCartDto.ProductId! });
        }
        else
        {
            var products = JsonConvert.DeserializeObject<List<string>>(productsJson);

            if (!products!.Contains(addToCartDto.ProductId!))
            {
                products?.Add(addToCartDto.ProductId!);
            }

            cacheValue = JsonConvert.SerializeObject(products);
        }

        await _distributedCache.SetStringAsync(cacheKey, cacheValue,
            new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });

        return Ok();
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetCart(Guid userId)
    {
        var productsJson = await _distributedCache.GetStringAsync(userId.ToString());

        var products = productsJson == null ?
            new List<string>() :
            JsonConvert.DeserializeObject<List<string>>(productsJson);

        return Ok(products);
    }
}