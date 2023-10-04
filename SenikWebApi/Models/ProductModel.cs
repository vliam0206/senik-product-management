namespace SenikWebApi.Models;

public class ProductModel
{
    public string Name { get; set; } = default!;
    public string? Image { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "Active";
    public string Category { get; set; } = default!;
}
