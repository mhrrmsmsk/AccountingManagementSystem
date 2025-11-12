using AccountSystem.Dtos.Company;
using AccountSystem.Entities;

namespace AccountSystem.Interfaces;

public interface ICompanyRepository
{
    public Task<List<Company>> GetAllAsync();
    public Task<Company?> GetByIdAsync(int id);
    public Task<Company> CreateAsync(Company company);
    public Task<Company> UpdateAsync(int id, UpdateCompanyRequestDto company);
    public Task<Company> DeleteAsync(int id);
}