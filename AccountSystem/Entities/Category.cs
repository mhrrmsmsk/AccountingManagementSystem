using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;

[Table("categories")]
public class Category
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public string CategoryName { get; set; } = string.Empty;
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public string CategoryDescription { get; set; } = string.Empty;
    
    public bool Status { get; set; } = true;
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
    
    // Navigation Properties
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
}