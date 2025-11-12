using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("units")]
public class Unit
{
    public int Id { get; set; }
    public string UnitName { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}