using AccountSystem.Data;
using AccountSystem.Dtos.Product;
using AccountSystem.Entities;
using AccountSystem.Helpers;
using AccountSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetAllByCompanyIdAsync(int companyId)
    {
        var products = await _context
            .Products
            .Include(p => p.Company)
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Where(p  => p.CompanyId == companyId && p.DeletedAt == null )
            .ToListAsync();
        return products;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context
            .Products
            .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);
        return product;
    }
    
    public async Task<List<ProductDetailDto>> GetDetailedByCompanyIdAsync(int companyId)
    {
        var sql = @"
        SELECT 
            p.Id,
            p.ProductCode,
            p.ProductName,
            c.CompanyName AS CompanyName,
            cat.CategoryName AS CategoryName,
            u.UnitName AS UnitName,
            p.Barcode,
            p.Description,
            p.PurchasePrice,
            p.SalePrice,
            p.VatRate,
            p.MinStock,
            p.MaxStock,
            p.Status
        FROM Products p
        JOIN Companies c ON p.CompanyId = c.Id
        JOIN Categories cat ON p.CategoryId = cat.Id
        JOIN Units u ON p.UnitId = u.Id
        WHERE p.CompanyId = {0} AND p.DeletedAt IS NULL
    ";

        var result = await _context.Set<ProductDetailDto>()
            .FromSqlRaw(sql, companyId)
            .ToListAsync();

        return result;
    }

    public async Task<List<Product>> GetAllAsync(QueryObject query)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Company)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(query.ProductName))
        { 
            products = products.Where(s => s.ProductName.Contains(query.ProductName));
        }
        
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("ProductName", StringComparison.OrdinalIgnoreCase))
            {
                products = query.IsDescending 
                    ? products.OrderByDescending(s => s.ProductName) 
                    : products.OrderBy(s => s.ProductName);
            }
            else if (query.SortBy.Equals("SalePrice", StringComparison.OrdinalIgnoreCase))
            {
                products = query.IsDescending 
                    ? products.OrderByDescending(s => s.SalePrice) 
                    : products.OrderBy(s => s.SalePrice);
            }
        }
        
        var skipNumber = (query.PageNumber - 1) * query.PageSize;

        return await products
            .Skip(skipNumber)
            .Take(query.PageSize)
            .ToListAsync();
    }

    public async Task<List<Product>> GetLowStockByCompanyAsync(int companyId)
    {
        return await _context.Products
            .Where(p => p.CompanyId == companyId && p.Status && p.DeletedAt == null && p.MinStock >= p.CurrentStock) 
            .ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var productModel = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);
        if (productModel == null)
        {
            return null;
        }
        productModel.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return productModel;
    }
}