using Merchant.Api.Data;
using Merchant.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext context;

    public ProductRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateProductAsyc(Product entity)
    {
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Product?> GetProductById(Guid productId)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        return product;
    }

    public async Task<List<Product>?> GetProducts()
    {
        var products = await context.Products.ToListAsync();
        return products;
    }

    public async Task UpdateProductAsync(Product entity)
    {
        context.Products.Update(entity);
        await context.SaveChangesAsync();
    }
}
