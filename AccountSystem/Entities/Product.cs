using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("products")]
public class Product
{
    public int Id { get; set; } // PK

    public int CompanyId { get; set; } // FK
    public Company Company { get; set; } 

    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;

    public int CategoryId { get; set; } // FK
    public Category Category { get; set; }

    public int UnitId { get; set; } // FK
    public Unit Unit { get; set; } 

    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }

    public decimal VatRate { get; set; } 
    public int CurrentStock { get; set; } = 0;

    public int MinStock { get; set; }
    public int MaxStock { get; set; }

    public bool Status { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}