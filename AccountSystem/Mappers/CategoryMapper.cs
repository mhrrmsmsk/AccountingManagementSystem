using AccountSystem.Dtos.Category;
using AccountSystem.Entities;

namespace AccountSystem.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            CompanyId = category.CompanyId,
            CategoryDescription = category.CategoryDescription,
            CategoryName = category.CategoryName,
            Status = category.Status,
        };
    }
    public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto dto)
    {
        return new Category
        {
            CategoryDescription = dto.CategoryDescription,
            CategoryName = dto.CategoryName,
            CompanyId = dto.CompanyId,
            Status = dto.Status,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = null
        };
    }
    public static Category ToCategoryFromUpdateDto(this UpdateCategoryRequestDto dto)
    {
        return new Category
        {
            CategoryDescription = dto.CategoryDescription,
            CategoryName = dto.CategoryName,
            Status = dto.Status,
            UpdatedAt = DateTime.Now,
        };
    }
}