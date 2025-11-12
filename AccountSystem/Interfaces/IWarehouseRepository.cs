using AccountSystem.Entities;

namespace AccountSystem.Interfaces;

public interface IWarehouseRepository
{
    public Task<List<Warehouse>> GetAllByCompanyIdAsync(int companyId);
    public Task<Warehouse?> GetByIdAsync(int id);
    public Task<Warehouse> CreateAsync(Warehouse warehouse);
    public Task<Warehouse> UpdateAsync(int id, Warehouse warehouse);
    public Task<Warehouse> DeleteAsync(int id);
}