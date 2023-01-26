using System.Security.Claims;
using Cart.Api.Dtos;
using Cart.Api.Entities;
using Cart.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
    {
        await _cartService.AddProductAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value, createProductDto);

        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetUserCart() =>
        Ok(await _cartService.GetUserCartAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _cartService.UpdateProductAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value, updateProductDto);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(string productId)
    {
        await _cartService.DeleteProductAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value, productId);

        return Ok();
    }

    [HttpDelete("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUserCart()
    {
        await _cartService.DeleteUserCartAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        return Ok();
    }
}