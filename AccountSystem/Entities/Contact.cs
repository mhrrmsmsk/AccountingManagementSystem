using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;
[Table("contacts")]
public class Contact
{
    public int Id { get; set; } // PK

    public int CompanyId { get; set; } // FK
    public Company Company { get; set; }

    public string ContactCode { get; set; } = string.Empty;
    public string ContactType { get; set; } = string.Empty; 
    // "customer", "supplier", "both"

    public string CompanyName { get; set; } = string.Empty;
    public string TaxOffice { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public decimal Balance { get; set; }
    public bool Status { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}