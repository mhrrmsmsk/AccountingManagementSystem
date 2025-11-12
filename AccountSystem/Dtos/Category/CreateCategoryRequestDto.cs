namespace AccountSystem.Dtos.Category;

public class CreateCategoryRequestDto
{
    public int CompanyId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
}