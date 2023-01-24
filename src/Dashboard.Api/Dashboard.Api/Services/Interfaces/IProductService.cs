using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductView>> GetProductsAsync();
    Task<ProductView> GetProductByIdAsync(Guid productId);
}