using AccountSystem.Data;
using AccountSystem.Entities;
using AccountSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repository;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly ApplicationDbContext _context;
    public WarehouseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Warehouse>> GetAllByCompanyIdAsync(int companyId)
    {
        return await _context.Warehouses.Where(w => w.DeletedAt == null).ToListAsync();
    }

    public async Task<Warehouse?> GetByIdAsync(int id)
    {
        var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == id && w.DeletedAt == null);
        if (warehouse == null)
            return null;
        return warehouse;
    }

    public async Task<Warehouse> CreateAsync(Warehouse warehouse)
    {
        throw new NotImplementedException();
    }

    public async Task<Warehouse> UpdateAsync(int id, Warehouse warehouse)
    {
        throw new NotImplementedException();
    }

    public async Task<Warehouse> DeleteAsync(int id)
    {
        var deletedWarehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == id && w.DeletedAt == null);
        if (deletedWarehouse == null)
            return null;
        deletedWarehouse.DeletedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return deletedWarehouse;
    }
}