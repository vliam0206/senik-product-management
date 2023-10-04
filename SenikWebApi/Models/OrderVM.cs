using Domain.Enums;
using Domain;

namespace SenikWebApi.Models;

public class OrderVM : BaseEntity
{
    public string CustomerName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public double TotalMoney { get; set; } = 0;
    public int TotalQuantity { get; set; } = 0;
    public DateTime? ShippedDate { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string Status { get; set; } = default!;

    public ICollection<OrderDetailVM> Products { get; set; } = new List<OrderDetailVM>();
}
