using Dashboard.Api.ModelsDto;
using Dashboard.Api.Services.Interfaces;
using Dashboard.Api.ViewModels;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.AspNetCore.Mvc;


namespace Dashboard.Api.Controllers;
[Route("api/[controller]")]
[Scoped]
public class CategoriesController : Controller
{
    private readonly UpdateCategoryDto _updateCategoryDto;
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(UpdateCategoryDto updateCategoryDto, ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
        _updateCategoryDto = updateCategoryDto;
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
    public async Task<IActionResult> GetCategoryById(Guid categoryId)
    {
        await _categoriesService.GetCategoryByIdAsync(categoryId);
        return Ok();
    }

    [HttpPut("{categoryId:guid}")]
    public async Task<IActionResult> UpdateCategories(Guid categoryId, UpdateCategoryDto updateCategoryDto)
    {
        await _categoriesService.UpdateCategoriesStatus(updateCategoryDto, categoryId);
        return Ok();
    }
}