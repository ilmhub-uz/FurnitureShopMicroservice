using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		public async Task<IActionResult> CreateProduct() 
			=> Ok();

		public async Task<IActionResult> GetProduct()
			=> Ok();

		public async Task<IActionResult> GetProductById()
			=> Ok();

		public async Task<IActionResult> UpdateProduct()
			=> Ok();

		public async Task<IActionResult> DeleteProduct()
			=> Ok();

	}
}
