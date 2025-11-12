namespace AccountSystem.Dtos.User;

public class UpdateUserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int RoleId { get; set; }
    public bool Status { get; set; }
}