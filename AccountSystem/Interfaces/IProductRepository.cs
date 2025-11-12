using AccountSystem.Dtos.Product;
using AccountSystem.Entities;
using AccountSystem.Helpers;

namespace AccountSystem.Interfaces;

public interface IProductRepository
{
    public Task<List<Product>> GetAllByCompanyIdAsync(int companyId);
    public Task<List<ProductDetailDto>> GetDetailedByCompanyIdAsync(int companyId);
    public Task<Product?> GetByIdAsync(int id);
    public Task<List<Product>> GetAllAsync(QueryObject query);
    Task<List<Product>> GetLowStockByCompanyAsync(int companyId);
    public Task<Product> AddAsync(Product product);
    public Task<Product> DeleteAsync(int id);
}