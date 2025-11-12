using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("warehouses")]
public class Warehouse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string WarehouseName { get; set; }
    public string WarehouseCode { get; set; }
    public string Address { get; set; }
    public string ResponsiblePerson { get; set; }
    public string PhoneNumber { get; set; }
    public bool Status { get; set; }
    public DateTime UpdatedAt { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
    
}