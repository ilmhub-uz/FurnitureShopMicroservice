using FluentValidation;
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
		private readonly IValidator<CreateProductDto> _createProductValidator;
		public ProductController(IProductRepository repository, IValidator<CreateProductDto> createProductValidator)
		{
			this.repository = repository;
			_createProductValidator = createProductValidator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			var result = _createProductValidator.Validate(createProductDto);

			if (!result.IsValid)
				return BadRequest(result.Errors);

			var product = await repository.CreateProductAsync(createProductDto);

			return Ok(product);
		}

		[HttpGet]
		public async Task<IActionResult> GetProduct([FromQuery] ProductFilterDto filterDto)
		=> Ok(await repository.GetAllProductAsync(filterDto));

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
