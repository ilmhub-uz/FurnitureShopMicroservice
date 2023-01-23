using MongoDB.Bson;
using MongoDB.Driver;
using Product.Api.Entities;

namespace Product.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<ProductModel> _products;

        public ProductRepository()
        {
            _mongoClient = new MongoClient("mongodb://mongodb:27017");
            _database = _mongoClient.GetDatabase("products_db");
            _products = _database.GetCollection<ProductModel>("products");
        }
        public async Task CreateProductAsync(ProductModel product)
        {
            product.Id = Guid.Parse(ObjectId.GenerateNewId(DateTime.Now).ToString());

            await _products.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var result = await _products.DeleteOneAsync(e => e.Id == productId);
            if (result.DeletedCount == 0)
                throw new Exception();
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductAsync()
        {
            var products = await(await _products.FindAsync(product => true)).ToListAsync();

            return products;
        }

        public async Task<ProductModel> GetProductAsync(Guid productId)
        {
            var product = await (await _products.FindAsync(product => product.Id==productId)).SingleOrDefaultAsync();
            if(product is null)
                throw new Exception();
            return product;
        }

        public async Task<ProductModel> UpdateProductAsync(Guid productId, ProductModel productModel)
        {
            var product = await (await _products.FindAsync(product => product.Id == productId)).SingleOrDefaultAsync();
            product.Id = productId;
            await _products.ReplaceOneAsync(e => e.Id == productId,productModel, new ReplaceOptions { IsUpsert = true });
            return product;
        }
    }
}
