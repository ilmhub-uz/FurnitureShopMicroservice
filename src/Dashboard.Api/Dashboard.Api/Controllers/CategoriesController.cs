using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JFA.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategories()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategories()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DaleteCategories()
    {
        return Ok();
    }
}