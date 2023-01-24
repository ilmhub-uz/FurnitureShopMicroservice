using Dashboard.Api.ModelsDto;
using Dashboard.Api.ViewModels;

namespace Dashboard.Api.Services.Interfaces;

public interface ICategoriesService
{
    Task<CategoryView> GetCategoryByIdAsync(int categoryId);
    Task AddCategory(CreateCategoryDto categoryDto);
    Task UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int categoryId);
}