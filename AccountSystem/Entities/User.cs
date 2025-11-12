using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AccountSystem.Entities;

[Table("users")]
public class User : IdentityUser<int>
{
    public int CompanyId { get; set; } 
    public Company Company { get; set; } = null!;
    public string FullName { get; set; } = string.Empty;
    public int RoleId { get; set; } 
    public Role Role { get; set; } = null!;
    public bool Status { get; set; } = true;
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;

    // Navigation
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<CashRegisterTransaction> CashTransactions { get; set; } = new List<CashRegisterTransaction>();
    public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
}