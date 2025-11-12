using AccountSystem.Data;
using AccountSystem.Dtos.Company;
using AccountSystem.Entities;
using AccountSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repository;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    
    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Company>> GetAllAsync()
    {
        return await _context.Companies.Where(c => c.DeletedAt == null).ToListAsync();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
       return await _context.Companies.Where(c=>c.DeletedAt==null).FirstOrDefaultAsync(c=>c.Id == id);
    }

    public async Task<Company> CreateAsync(Company company)
    {
       await _context.Companies.AddAsync(company);
       await _context.SaveChangesAsync();
       return company;
    }

    public async Task<Company> UpdateAsync(int id, UpdateCompanyRequestDto company)
    {
        var companyModel = await _context.Companies
            .Where(c=>c.DeletedAt==null)
            .FirstOrDefaultAsync(c=>c.Id == id);
        
        if (companyModel == null)
            return null;
        companyModel.CompanyName = company.CompanyName;
        companyModel.Address = company.Address;
        companyModel.TaxNumber = company.TaxNumber;
        companyModel.PhoneNumber = company.PhoneNumber;
        companyModel.Email = company.Email;
        companyModel.Website = company.Website;
        companyModel.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return companyModel;
    }

    public async Task<Company> DeleteAsync(int id)
    {
        var companyModel = await _context
            .Companies
            .Where(c=>c.DeletedAt==null)
            .FirstOrDefaultAsync(c=>c.Id == id);
        if (companyModel == null)
        {
            return null;
        }
        companyModel.DeletedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return companyModel;
    }
}