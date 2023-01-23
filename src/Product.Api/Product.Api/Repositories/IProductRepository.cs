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

        Task DeleteProductAsync(Guid productId);
        Task<IEnumerable<ProductModel>> GetAllProductAsync();
        Task<ProductViewModel> GetProductAsync(Guid productId);
        Task<ProductModel> UpdateProductAsync(Guid productId, ProductModel productModel);
    }
}
