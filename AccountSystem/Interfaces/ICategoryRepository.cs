using AccountSystem.Dtos.Category;
using AccountSystem.Entities;

namespace AccountSystem.Interfaces;

public interface ICategoryRepository
{
    public Task<List<Category>> GetCategoryByCompanyId(int companyId);
    public Task<List<object>> GetAllCategoriesAsync(int companyId);
    public Task<Category?> GetCategoryById(int id);
    public Task<Category> CreateCategory(Category category);
    public Task<Category> UpdateCategory(int id, Category category);
    public Task<Category> DeleteCategory(int id);
}