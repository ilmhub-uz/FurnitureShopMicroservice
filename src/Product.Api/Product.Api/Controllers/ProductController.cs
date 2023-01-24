using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Entities.Dtos;
using Product.Api.RabbitMq;
using Product.Api.Repositories;

namespace Product.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductRepository repository;
		public ProductController(IProductRepository repository)
		{
			this.repository = repository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await repository.CreateProductAsync(createProductDto);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetProduct()
		=> Ok(await repository.GetAllProductAsync());

		[HttpGet("getbyId")]
		public async Task<IActionResult> GetProductById(string productId)
			=> Ok(await repository.GetProductAsync(productId));

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(string productId, UpdateProductDto productDto)
		{
			var product = await repository.UpdateProductAsync(productId, productDto);
			return Ok(product);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(string productId)
		{
			await repository.DeleteProductAsync(productId);
			return Ok();
		}
	}
}
