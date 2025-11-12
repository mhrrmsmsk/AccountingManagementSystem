using Microsoft.AspNetCore.Identity;

namespace AccountSystem.Entities;

public class Role : IdentityRole<int> 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public DateTime? DeletedAt { get; set; } = null;
    public List<User> Users { get; set; } = new();
}