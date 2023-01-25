using Dashboard.Api.Context;
using Dashboard.Api.Entities;
using Dashboard.Api.Exceptions;
using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;

[Scoped]
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
        if (products is null)
        {
            throw new NotFoundException<Product>();
        }

        return products.Adapt<List<ProductView>>();
    }

    public async Task<ProductView> GetProductByIdAsync(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
        {
            throw new NotFoundException<Product>();
        }

        return product.Adapt<ProductView>();
    }

    public async Task<ProductView> UpdateProduct(Guid productId, UpdateProductDto updateProductDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (product is null)
        {
            throw new NotFoundException<Product>();
        }
        product.Status = updateProductDto.Status;
        return product.Adapt<ProductView>();
    }
}