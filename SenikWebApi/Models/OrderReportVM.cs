using Domain.Enums;

namespace SenikWebApi.Models;

public class OrderReportVM
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public double TotalMoney { get; set; } = 0;
    public int TotalQuantity { get; set; } = 0;
    public DateTime CreationDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public PaymentEnum PaymentMethod { get; set; }
    public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Waiting;
    public string Items { get; set; } = "";
}
