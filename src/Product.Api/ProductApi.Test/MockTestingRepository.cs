using Product.Api.RabbitMq;
using Product.Api.Repositories;
using Product.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.Enums;
using Microsoft.Extensions.Options;

namespace Product.Api.Test
{
	public class MockTestingRepository
	{
		private readonly Mock<IOptions<AppSettings>> settings;
		private readonly Mock<SendToGetMessage> sendToGet;
		private readonly Mock<IProductRepository> productRepository;
		private readonly ProductRepository repository;
		public MockTestingRepository()
		{
			settings = new Mock<IOptions<AppSettings>>();
			settings.Setup(s => s.Value).Returns(new AppSettings
			{
				MongoDbConnectionStrings = "mongodb://localhost:27017"
			}); ;

			sendToGet = new Mock<SendToGetMessage>();
			productRepository = new Mock<IProductRepository>();
			repository = new ProductRepository(settings.Object, sendToGet.Object);
		}

		[Fact]
		public async Task TestCreateProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			var product = await repository.CreateProductAsync(dto);

			//Assert
			Assert.NotNull(product);
			Assert.Equal("Test", product.Name);
			Assert.Equal(1000, product.Price);
		}

		[Fact]
		public async Task TestDeleteProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			var product = await repository.CreateProductAsync(dto);
			await repository.DeleteProductAsync(product.Id);

			var products = await repository.GetAllProductAsync(new ProductFilterDto());
			var deleteproduct = products.FirstOrDefault(p => p.Id == product.Id);

			//Assert
			Assert.Null(deleteproduct);
		}

		[Fact]
		public async Task TestUpdateProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			var product = await repository.CreateProductAsync(dto);
			var updatedto = new UpdateProductDto()
			{
				Name = "Update",
				Price = 2000,
				Status = EProductStatus.Active,
			};
			await repository.UpdateProductAsync(product.Id, updatedto);
			var updateproduct = await repository.GetProductAsync(product.Id);

			//Assert
			Assert.NotNull(updateproduct);
			Assert.Equal(EProductStatus.Active, updateproduct.Status);
			Assert.Equal("Update", updateproduct.Name);
			Assert.Equal(2000, updateproduct.Price);
		}

		[Fact]
		public async Task TestGetProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			var product = await repository.CreateProductAsync(dto);
            var currentproduct = await repository.GetProductAsync(product.Id);

			//Assert
			Assert.NotNull(currentproduct);
			Assert.Equal("Test",currentproduct.Name);
			Assert.Equal(1000,currentproduct.Price);
		}
	}
}
