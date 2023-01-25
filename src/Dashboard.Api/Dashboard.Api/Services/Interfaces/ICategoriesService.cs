using Dashboard.Api.ModelsDto;
using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface ICategoriesService
{
    Task<CategoryView> GetCategoryByIdAsync(Guid categoryId);
    Task<List<CategoryView>> GetCategories();
    Task UpdateCategoriesStatus(UpdateCategoryDto updateCategoryDto, Guid categoryId);
}