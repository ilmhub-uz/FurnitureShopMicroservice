﻿using Mapster;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.Api.Entities;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.ViewModels;
using Product.Api.Exceptions;
using Product.Api.Services;

namespace Product.Api.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly MongoClient _mongoClient;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<ProductModel> _products;
		private IOptions<AppSettings> _appsettings;
		public ProductRepository(IOptions<AppSettings> appsettings)
		{
			_appsettings = appsettings;
			_mongoClient = new MongoClient(_appsettings.Value.MongoDbConnectionStrings);
			_database = _mongoClient.GetDatabase("products_db");
			_products = _database.GetCollection<ProductModel>("products");
		}

		public async Task CreateProductAsync(CreateProductDto productDto)
		{
			var product = productDto.Adapt<ProductModel>();
			product.Id = ObjectId.GenerateNewId(DateTime.Now).ToString();
			if(_products.Equals(product))
			await _products.InsertOneAsync(product);
		}

		public async Task DeleteProductAsync(string productId)
		{
			var result = await _products.DeleteOneAsync(e => e.Id == productId);
			if (result.DeletedCount == 0)
				throw new Exception();
		}

		public async Task<IEnumerable<ProductModel>> GetAllProductAsync()
		{
			var products = await (await _products.FindAsync(product => true)).ToListAsync();
			if(products.Count == 0)
				throw new Exception("products is empty");
			return products;
		}

		public async Task<ProductViewModel> GetProductAsync(string productId)
		{
			var product = await (await _products.FindAsync(product => product.Id == productId)).SingleOrDefaultAsync();
			if (product is null)
				throw new NotFoundException<ProductModel>();
			return product.Adapt<ProductViewModel>();
		}

		public async Task<ProductModel> UpdateProductAsync(string productId, UpdateProductDto productDto)
		{
			var filter = Builders<ProductModel>.Filter.Eq("_id", productId);
			if (filter is null)
				throw new NotFoundException<ProductModel>();
			var update = Builders<ProductModel>.Update
				.Set("Name", productDto.Name)
				.Set("Description", productDto.Description)
				.Set("WithInstallation", productDto.WithInstallation)
				.Set("Brend", productDto.Brend)
				.Set("Material", productDto.Material)
				.Set("Price", productDto.Price)
				.Set("IsAvailable", productDto.IsAvailable)
				.Set("Count", productDto.Count);

			var options = new FindOneAndUpdateOptions<ProductModel> { ReturnDocument = ReturnDocument.After };

			var product = await _products.FindOneAndUpdateAsync(filter, update, options);
			return product;
		}
	}
}
