using Microsoft.Extensions.Options;
using Product.Api.Entities.Dtos;
using Product.Api.RabbitMq;
using Product.Api.Repositories;
using Product.Api.Services;
using Xunit;

namespace Product.Api.Tests
{
	public class MockTestRepository
	{
		[Fact]
		public async Task TestCreateProductAsync()
		{
			//Arrange
			var productDto = new CreateProductDto { Name = "Test Product", Price = 10 };
			var sendToGet = new SendToGetMessage();
			var options = Options.Create(new AppSettings { MongoDbConnectionStrings = "mongodb://localhost:27017" });
			var repository = new ProductRepository(options, sendToGet);

			//Act
			await repository.CreateProductAsync(productDto);
			var product = await repository.GetProductAsync("Test Product");

			//Assert
			Assert.NotNull(product);
			Assert.Equal("Test Product", product.Name);
			Assert.Equal(10, product.Price);
		}

		[Fact]
		public async Task TestDeleteProductAsync()
		{
			//Arrange
			var productDto = new CreateProductDto { Name = "Test Product", Price = 10 };
			var sendToGet = new SendToGetMessage();
			var options = Options.Create(new AppSettings { MongoDbConnectionStrings = "mongodb://localhost:27017" });
			var repository = new ProductRepository(options, sendToGet);
			await repository.CreateProductAsync(productDto);

			//Act
			await repository.DeleteProductAsync("Test Product");
			var exceptionThrown = false;
			try
			{
				await repository.GetProductAsync("Test Product");
			}
			catch (Exception)
			{
				exceptionThrown = true;
			}

			//Assert
			Assert.True(exceptionThrown);
		}

	}
}
