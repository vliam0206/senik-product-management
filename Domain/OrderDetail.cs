namespace Domain;

public class OrderDetail : BaseEntity
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }

    public Product Product { get; set; } = default!;
    public Order Order { get; set; } = default!;
}
