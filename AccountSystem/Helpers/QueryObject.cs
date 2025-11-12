namespace AccountSystem.Helpers;

public class QueryObject
{
    public string? ProductName { get; set; }
    public string? CategoryName { get; set; }
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}