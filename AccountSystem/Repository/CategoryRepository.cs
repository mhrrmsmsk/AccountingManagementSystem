using AccountSystem.Data;
using AccountSystem.Dtos.Category;
using AccountSystem.Entities;
using AccountSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Category>> GetCategoryByCompanyId(int companyId)
    {
        return await _context.Categories
            .Where(c => c.CompanyId == companyId && c.DeletedAt ==null)
            .ToListAsync();
    }

    public async Task<List<object>> GetAllCategoriesAsync(int companyId)
    {
        var categories = await _context.Categories
            .Where(c => c.CompanyId == companyId && c.DeletedAt ==null)
            .ToListAsync();
        
        var rootCategories = categories
            .Where(c => c.ParentCategoryId == null)
            .ToList();
        
        List<object> BuildTree(Category parent)
        {
            return categories
                .Where(c => c.ParentCategoryId == parent.Id)
                .Select(c => new
                {
                    id = c.Id,
                    name = c.CategoryName,
                    description = c.CategoryDescription,
                    children = BuildTree(c)
                })
                .ToList<object>();
        }

        var result = rootCategories
            .Select(c => new
            {
                id = c.Id,
                name = c.CategoryName,
                description = c.CategoryDescription,
                children = BuildTree(c)
            })
            .ToList<object>();

        return result;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.DeletedAt == null);
        if (category == null)
            return null;
        return category;
    }

    public async Task<Category> CreateCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategory(int id, Category category)
    {
        var categoryModel = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.DeletedAt == null);
        if (categoryModel == null)
            return null;
        categoryModel.CategoryName = category.CategoryName;
        categoryModel.CategoryDescription = category.CategoryDescription;
        categoryModel.Status = category.Status;
        categoryModel.UpdatedAt = category.UpdatedAt;
        await _context.SaveChangesAsync();
        return categoryModel;
    }

    public async Task<Category> DeleteCategory(int id)
    {
        var categoryModel = await _context.Categories
            .Where(c => c.DeletedAt == null)
            .FirstOrDefaultAsync(c=>c.Id == id);
        if (categoryModel == null)
            return null;
        
        categoryModel.DeletedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return categoryModel;
    }
}