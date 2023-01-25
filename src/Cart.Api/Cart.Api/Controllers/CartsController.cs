using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Cart.Api.Dtos;
using Cart.Api.Entities;
using Mapster;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddProduct(string key, CreateProductDto createProductDto)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);
        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson ?? string.Empty);
        var product = createProductDto.Adapt<Product>();
        
        products ??= new List<Product>();

        products.Add(product);
        
        await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(products), new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromDays(10)
        });

        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetCart(string key)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            return Ok(new List<string>());

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

        return Ok(products);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct(string key, UpdateProductDto updateProductDto)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            return BadRequest();

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
        var product = products!.FirstOrDefault(product => product.Id == updateProductDto.Id);

        if (product is null)
            return BadRequest();

        products!.Remove(product);
        products.Add(updateProductDto.Adapt<Product>());

        await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(products), new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromDays(10)
        });

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct(string key, string productId)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            return BadRequest();

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
        var product = products!.FirstOrDefault(product => product.Id == productId);

        if (products is null)
            return BadRequest();

        products.Remove(product!);

        return Ok(product);
    }

    [HttpDelete("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUserCart(string key)
    {
        await _distributedCache.RemoveAsync(key);

        return Ok();
    }
}