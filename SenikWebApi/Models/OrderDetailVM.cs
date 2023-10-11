namespace SenikWebApi.Models;

public class OrderDetailVM
{
    public int ProductId { get; set; }
    public string Name { get; set; } = default!;
    public double UnitPrice { get; set; }
    public string? Image { get; set; }
    public string Category { get; set; } = default!;
    public int Quantity { get; set; }    
}
