using Domain.Enums;

namespace SenikWebApi.Models;

public class ProductModel
{
    public string Name { get; set; } = default!;
    public string? Image { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public ProductStatusEnum Status { get; set; } = 0;
    public CategoryEnum Category { get; set; } = default!;
    public bool IsDeleted { get; set; } = false;
}
