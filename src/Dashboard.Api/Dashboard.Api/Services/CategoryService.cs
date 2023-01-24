using Dashboard.Api.Context;
using Dashboard.Api.ModelsDto;
using Dashboard.Api.ViewModels;
using Dashboard.Api.Entities;
using JFA.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Services;

[Scoped]
public class CategoryService
{
    private readonly AppDbContext _context;
    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<CategoryView>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.Where(c => c.ParentId == null).ToListAsync();

        var categoriesViewList = new List<CategoryView>();

        foreach (var category in categories)
        {
            var categoryView = ConvertToCategoryView(category);

            categoriesViewList.Add(categoryView);
        }

        return categoriesViewList;
    }
    private CategoryView ConvertToCategoryView(Category category)
    {
        var categoryView = new CategoryView()
        {
            Id = category.Id,
            Name = category.Name,
        };

        if (category.Children is null)
            return categoryView;

        foreach (var child in category.Children)
        {
            categoryView.Children ??= new List<CategoryView>();
            categoryView.Children.Add(ConvertToCategoryView(child));
        }

        return categoryView;
    }
    public async Task<CategoryView> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category is null)
            throw new NotFoundException<Category>();

        return ConvertToCategoryView(category);
    }
    public async Task AddCategory(CreateCategoryDto categoryDto)
    {
        var category = new Category()
        {
            Name = categoryDto.Name,
            ParentId = categoryDto.ParentId,
        };

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category is null)
            throw new NotFoundException<Category>();

        category.Name = updateCategoryDto.Name;
        category.ParentId = updateCategoryDto.ParentId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category is null)
            throw new NotFoundException<Category>();

        await _context.SaveChangesAsync();
    }
}