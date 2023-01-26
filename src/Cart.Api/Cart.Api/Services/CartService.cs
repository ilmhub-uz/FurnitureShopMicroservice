using Cart.Api.Dtos;
using Cart.Api.Entities;
using Cart.Api.Exceptions;
using Mapster;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Cart.Api.Services;

public class CartService : ICartService
{
    private readonly IDistributedCache _distributedCache;

    public CartService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }


    public async Task AddProductAsync(string key, CreateProductDto createProductDto)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);
        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson ?? string.Empty);
        var product = createProductDto.Adapt<Product>();

        products ??= new List<Product>();

        products.Add(product);

        await SaveCartToRedis(key, JsonConvert.SerializeObject(products));
    }

    public async Task<List<Product>> GetUserCartAsync(string key)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            return new List<Product>();

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

        return products!;
    }

    public async Task UpdateProductAsync(string key, UpdateProductDto updateProductDto)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            throw new BadRequestException("Products is null in this user's cart");

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
        var product = products!.FirstOrDefault(product => product.Id == updateProductDto.Id);

        if (product is null)
            throw new NotFoundException<Product>();

        products!.Remove(product);
        products.Add(updateProductDto.Adapt<Product>());

        await SaveCartToRedis(key, JsonConvert.SerializeObject(products));
    }

    public async Task DeleteProductAsync(string key, string productId)
    {
        var productsJson = await _distributedCache.GetStringAsync(key);

        if (productsJson is null)
            throw new BadRequestException("Products is null in this user's cart");

        var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
        var product = products!.FirstOrDefault(product => product.Id == productId);

        if (product is null)
            throw new NotFoundException<Product>();

        products!.Remove(product!);

        await SaveCartToRedis(key, JsonConvert.SerializeObject(products));
    }

    public async Task DeleteUserCartAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }

    private async Task SaveCartToRedis(string key, string value)
    {
        await _distributedCache.SetStringAsync(key, value, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromDays(10)
        });
    }
}