namespace AccountSystem.Dtos.Product;

public class CreateProductRequestDto
{
    public int CompanyId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int UnitId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }

    public decimal VatRate { get; set; } 
    public int CurrentStock { get; set; }

    public int MinStock { get; set; }
    public int MaxStock { get; set; }

    public bool Status { get; set; } = true;
}