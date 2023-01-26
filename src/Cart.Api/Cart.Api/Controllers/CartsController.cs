using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Cart.Api.Dtos;
using Cart.Api.Entities;
using Cart.Api.Services;
using Mapster;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Cart.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddProduct(string key, CreateProductDto createProductDto)
    {
        await _cartService.AddProductAsync(key, createProductDto);

        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetUserCart(string key) => Ok(await _cartService.GetUserCartAsync(key));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(string key, UpdateProductDto updateProductDto)
    {
        await _cartService.UpdateProductAsync(key, updateProductDto);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(string key, string productId)
    {
        await _cartService.DeleteProductAsync(key, productId);

        return Ok();
    }

    [HttpDelete("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUserCart(string key)
    {
        await _cartService.DeleteUserCartAsync(key);

        return Ok();
    }
}