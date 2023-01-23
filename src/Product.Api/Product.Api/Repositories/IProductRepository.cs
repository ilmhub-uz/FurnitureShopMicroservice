using Product.Api.Entities;

namespace Product.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProductAsync();
        Task<ProductModel> GetProductAsync(Guid productId);
        Task CreateProductAsync(ProductModel product);
        Task DeleteProductAsync(Guid productId);
        Task<ProductModel> UpdateProductAsync(Guid productId,ProductModel productModel);
    }
}
