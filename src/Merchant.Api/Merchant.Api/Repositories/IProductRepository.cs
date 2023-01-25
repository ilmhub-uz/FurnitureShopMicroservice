using Merchant.Api.Entities;

namespace Merchant.Api.Repositories;

public interface IProductRepository
{
    Task CreateProductAsyc(Product entity);
    Task UpdateProductAsync(Product entity);
    Task DeleteProductAsync(Product entity);
    Task<Product?> GetProductById(Guid productId);
    Task<List<Product>?> GetProducts();
}
