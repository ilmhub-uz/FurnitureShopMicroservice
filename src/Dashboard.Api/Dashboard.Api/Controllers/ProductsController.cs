using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly ProductService _productService;
    
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        var product =  await _productService.GetProductsAsync();
        return Ok(product);
    }

    [HttpGet("{product:guid}")]
    public async Task<IActionResult> GetProductsById(Guid productId)
    {
        await _productService.GetProductByIdAsync(productId);
        return Ok();
    }

    [HttpPut("{product:guid}")]
    public async Task<IActionResult> ProductUpdateStatus(Guid productId, UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProduct(productId, updateProductDto);
        return Ok();
    }
}