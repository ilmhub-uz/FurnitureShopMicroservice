using Dashboard.Api.ModelsDto;
using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductView>> GetProductsAsync();
    Task<ProductView> GetProductByIdAsync(Guid productId);
    Task<ProductView> UpdateProduct(Guid productId, UpdateProductDto updateProductDto);
}