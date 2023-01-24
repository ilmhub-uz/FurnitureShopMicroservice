using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        return Ok();
    }

    [HttpGet("product:Guid")]
    public async Task<IActionResult> GetProductsById(Guid productId)
    {
        return Ok();
    }

    [HttpPut("{product:Guid}")]
    public async Task<IActionResult> ProductUpdateStatus(Guid productsId)
    {
        return Ok();
    }

}