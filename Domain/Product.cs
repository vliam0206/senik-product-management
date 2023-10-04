using Domain.Enums;

namespace Domain;

public class Product : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Image { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public ProductStatusEnum Status { get; set; } = ProductStatusEnum.Active;
    public CategoryEnum Category { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
