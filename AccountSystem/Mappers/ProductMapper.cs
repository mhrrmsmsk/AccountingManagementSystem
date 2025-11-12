using AccountSystem.Dtos.Product;
using AccountSystem.Entities;

namespace AccountSystem.Mappers;

public static class ProductMapper
{
    public static Product ToProductFromCreateDto(this CreateProductRequestDto dto)
    {
        return new Product
        {
            CompanyId     = dto.CompanyId,
            ProductCode   = dto.ProductCode,
            ProductName   = dto.ProductName,
            CategoryId    = dto.CategoryId,
            UnitId        = dto.UnitId,
            Barcode       = dto.Barcode,
            Description   = dto.Description,
            PurchasePrice = dto.PurchasePrice,
            SalePrice     = dto.SalePrice,
            VatRate       = dto.VatRate,
            CurrentStock = dto.CurrentStock,
            MinStock      = dto.MinStock,
            MaxStock      = dto.MaxStock,
            Status        = dto.Status,
            CreatedAt     = DateTime.Now,
            UpdatedAt     = DateTime.Now,
            DeletedAt     = null
        };
    }

    public static ProductResponseDto ToProductResponseDto(this Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            ProductCode   = product.ProductCode,
            ProductName   = product.ProductName,
            CompanyId     = product.CompanyId,
            CategoryId    = product.CategoryId,
            UnitId        = product.UnitId,
            Barcode       = product.Barcode,
            Description   = product.Description,
            PurchasePrice = product.PurchasePrice,
            SalePrice     = product.SalePrice,
            VatRate       = product.VatRate,
            CurrentStock  = product.CurrentStock,
            MinStock      = product.MinStock,
            MaxStock      = product.MaxStock,
            Status        = product.Status,
        };
    }
    
}