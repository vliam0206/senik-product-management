namespace SenikWebApi.Models;

public class OrderDetailVM
{
    public int ProductId { get; set; }
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public string? Image { get; set; }
    public string Category { get; set; } = default!;
    public int Quantity { get; set; }    
}
