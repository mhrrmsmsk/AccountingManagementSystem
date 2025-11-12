using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("stock_movements")]
public class StockMovement
{
    public int Id { get; set; } 

    public int CompanyId { get; set; } 
    public Company Company { get; set; }
    public string MovementType { get; set; } = string.Empty; 
    public int ProductId { get; set; } 
    public Product Product { get; set; }

    public int WarehouseId { get; set; } 
    public Warehouse Warehouse { get; set; }

    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }

    public string DocumentNo { get; set; } = string.Empty;
    public DateTime MovementDate { get; set; }

    public string Description { get; set; } = string.Empty;

    public int UserId { get; set; } 
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public DateTime? DeletedAt { get; set; } = null;
    
}