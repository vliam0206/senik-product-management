namespace SenikWebApi.Models;

public class ProductOrderVM
{
    public string ProductName { get; set; } = default!;
    public string? Image { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; } = default!;
}
