using MongoDB.Bson;
using MongoDB.Driver;
using Product.Api.Entities;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.ViewModels;

namespace Product.Api.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(CreateProductDto productDto);
        Task DeleteProductAsync(string productId);
        Task<IEnumerable<ProductViewModel>> GetAllProductAsync(ProductFilterDto filterDto);
        Task<ProductViewModel> GetProductAsync(string productId);
        Task<ProductViewModel> UpdateProductAsync(string productId, UpdateProductDto productDto);
    }
}
