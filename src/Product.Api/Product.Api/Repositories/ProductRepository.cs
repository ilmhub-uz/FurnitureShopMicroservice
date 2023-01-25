using Mapster;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.Api.Entities;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.Enums;
using Product.Api.Entities.ViewModels;
using Product.Api.Exceptions;
using Product.Api.Helpers;
using Product.Api.RabbitMq;
using Product.Api.Services;

namespace Product.Api.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly MongoClient _mongoClient;
		private readonly SendToGetMessage sendToGet;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<ProductModel> _products;
		private IOptions<AppSettings> _appsettings;
		private AppSettings object1;
		private SendToGetMessage object2;

		public ProductRepository(IOptions<AppSettings> appsettings, SendToGetMessage sendToGet)
		{
			_appsettings = appsettings;
			_mongoClient = new MongoClient(_appsettings.Value.MongoDbConnectionStrings);
			_database = _mongoClient.GetDatabase("products_db");
			_products = _database.GetCollection<ProductModel>("products");
			this.sendToGet = sendToGet;
		}

		public ProductRepository(AppSettings object1, SendToGetMessage object2)
		{
			this.object1 = object1;
			this.object2 = object2;
		}

		public async Task CreateProductAsync(CreateProductDto productDto)
		{
			var product = productDto.Adapt<ProductModel>();
			product.Id = ObjectId.GenerateNewId(DateTime.Now).ToString();
			product.CreatedAt = DateTime.UtcNow;
			sendToGet.SendMessage(product);
			await _products.InsertOneAsync(product);
		}

		public async Task DeleteProductAsync(string productId)
		{
			var result = await _products.DeleteOneAsync(e => e.Id == productId);

			if (result.DeletedCount == 0)
				throw new Exception();
		}

		public async Task<IEnumerable<ProductViewModel>> GetAllProductAsync(ProductFilterDto filterDto)
		{
			var products = await (await _products.FindAsync(product => true)).ToListAsync();

			if (products is null)
				return new List<ProductViewModel>();

			products = filterDto.Status switch
			{
				EProductStatus.Active => products.Where(p => p.Status == filterDto.Status).ToList(),
				EProductStatus.Created => products.Where(p => p.Status == filterDto.Status).ToList(),
				EProductStatus.InActive => products.Where(p => p.Status == filterDto.Status).ToList(),
				EProductStatus.Deleted => products.Where(p => p.Status == filterDto.Status).ToList(),
				_ => products
			};

			if (filterDto.Name is not null) products = products.Where(p => p.Name.Contains(filterDto.Name)).ToList();
			if (filterDto.FromPrice is not null) products = products.Where(p => p.Price >= filterDto.FromPrice).ToList();
			if (filterDto.ToPrice is not null) products = products.Where(p => p.Price <= filterDto.ToPrice).ToList();

			products = filterDto.SortingStatus switch
			{
				EProductSortingStatus.Prices => products.OrderByDescending(p => p.Price).ToList(),
				EProductSortingStatus.Names => products.OrderByDescending(p => p.Name).ToList(),
				EProductSortingStatus.CreatedAtes => products.OrderByDescending(p => p.CreatedAt).ToList(),
				_ => products
			};

			var productList = products.Adapt<List<ProductViewModel>>().ToPagedList(filterDto);
            return productList;
		}

		public async Task<ProductViewModel> GetProductAsync(string productId)
		{
			var product = await (await _products.FindAsync(product => product.Id == productId)).SingleOrDefaultAsync();
			if (product is null)
				throw new NotFoundException<ProductModel>();
			return product.Adapt<ProductViewModel>();
		}

		public async Task<ProductViewModel> UpdateProductAsync(string productId, UpdateProductDto productDto)
		{
			var filter = Builders<ProductModel>.Filter.Eq("_id", productId);
			if (filter is null)
				throw new NotFoundException<ProductModel>();
			var product = productDto.Adapt<ProductModel>();
			product.Id = productId;
			await _products.ReplaceOneAsync(filter, product);
		    return product.Adapt<ProductViewModel>();
		}
	}
}
