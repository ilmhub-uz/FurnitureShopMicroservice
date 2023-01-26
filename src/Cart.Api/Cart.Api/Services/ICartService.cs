using Cart.Api.Dtos;
using Cart.Api.Entities;

namespace Cart.Api.Services;

public interface ICartService
{
    Task AddProductAsync(string key, CreateProductDto createProductDto);
    Task<List<Product>> GetUserCartAsync(string key);
    Task UpdateProductAsync(string key, UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string key, string productId);
    Task DeleteUserCartAsync(string key);
}