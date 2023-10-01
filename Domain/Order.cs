using Domain.Enums;

namespace Domain;

public class Order : BaseEntity
{
    public string CustomerName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public double TotalMoney { get; set; } = 0;
    public int TotalQuantity { get; set; } = 0;
    public DateTime? ShippedDate { get; set; }
    public PaymentEnum PaymentMethod { get; set; }
    public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Waiting;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public int? CustomerId { get; set; }
    public CustomerInfor? CustomerInfor { get; set; }
}
