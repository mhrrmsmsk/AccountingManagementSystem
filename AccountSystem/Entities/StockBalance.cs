using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("stock_balances")]
public class StockBalance
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public decimal Quantity { get; set; }
    public decimal AverageCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public DateTime? DeletedAt { get; set; } = null;
}