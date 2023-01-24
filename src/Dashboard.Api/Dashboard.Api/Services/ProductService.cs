using Dashboard.Api.Context;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductView>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        if (products is null) return new();

        return products.Adapt<List<ProductView>>();
    }

    public async Task<ProductView> GetProductByIdAsync(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null) throw new Exception();

        return product.Adapt<ProductView>();
    }
}