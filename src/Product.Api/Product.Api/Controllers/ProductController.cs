using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.ViewModels;
using Product.Api.Repositories;
using System.Collections.Generic;

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
		[ProducesResponseType(typeof(List<ProductViewModel>),StatusCodes.Status200OK)]
		public async Task<IActionResult> GetProduct()
		=> Ok(await repository.GetAllProductAsync());

		[HttpGet("getbyId")]
		[ProducesResponseType(typeof(ProductViewModel),StatusCodes.Status200OK)]
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
