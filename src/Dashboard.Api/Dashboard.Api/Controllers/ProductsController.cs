using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;

    }

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{productId:Guid}")]
    public async Task<IActionResult> GetProductsById(Guid productId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        return Ok(product);
    }

    [HttpPut("{productId:Guid}")]
    public async Task<IActionResult> ProductUpdateStatus(Guid productId, UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProduct(productId, updateProductDto);
        return Ok();
    }

}