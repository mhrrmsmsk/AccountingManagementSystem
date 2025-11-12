namespace AccountSystem.Dtos.Product;

using Microsoft.EntityFrameworkCore;

[Keyless] 
public class ProductDetailDto
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal VatRate { get; set; }
    public int MinStock { get; set; }
    public int MaxStock { get; set; }
    public bool Status { get; set; }
}