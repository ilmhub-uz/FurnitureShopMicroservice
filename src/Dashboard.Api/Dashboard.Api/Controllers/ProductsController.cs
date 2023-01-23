using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Api.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        return Ok();
    }

    [HttpGet("productId:Guid")]
    public async Task<IActionResult> GetProductsById(Guid productId)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ProductUpdate()
    {
        return Ok();
    }

}