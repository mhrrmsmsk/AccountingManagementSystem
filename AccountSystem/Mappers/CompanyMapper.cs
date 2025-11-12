using AccountSystem.Dtos.Company;
using AccountSystem.Entities;

namespace AccountSystem.Mappers;

public static class CompanyMapper
{
    public static CompanyDto ToCompanyDto(this Company company)
    {
        return new CompanyDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            TaxNumber = company.TaxNumber,
            Address = company.Address,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            Website = company.Website,
            Status = company.Status,
            CreatedAt = company.CreatedAt,
            UpdatedAt = company.UpdatedAt,
            DeletedAt = company.DeletedAt,
        };
    }

    public static Company ToCompanyFromCreateDto(this CreateCompanyRequestDto requestDto)
    {
        return new Company
        {
            CompanyName = requestDto.CompanyName,
            TaxNumber = requestDto.TaxNumber,
            Address = requestDto.Address,
            PhoneNumber = requestDto.PhoneNumber,
            Email = requestDto.Email,
            Website = requestDto.Website,
            Status = true,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = null,
        };
    }
}