using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.AspNetCore.Mvc;


namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        var category = await _categoriesService.GetCategories();
        return Ok(category);
    }

    [HttpGet("{categoryId:guid}")]
    [ProducesResponseType(typeof(CategoryView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        await _categoriesService.GetCategoryByIdAsync(categoryId);
        return Ok();
    }

    [HttpPut("{categoryId:guid}")]
    public async Task<IActionResult> UpdateCategories(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        await _categoriesService.UpdateCategoriesStatus(updateCategoryDto, categoryId);
        return Ok();
    }
}