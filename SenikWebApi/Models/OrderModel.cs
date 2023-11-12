using Domain.Enums;

namespace SenikWebApi.Models;

public class OrderModel
{
    public string CustomerName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public DateTime? ShippedDate { get; set; }
    public PaymentEnum PaymentMethod { get; set; } = PaymentEnum.COD;
    public bool IsDeleted { get; set; } = false;

    public ICollection<OrderDetailModel> Products { get; set; } = new List<OrderDetailModel>();
}
