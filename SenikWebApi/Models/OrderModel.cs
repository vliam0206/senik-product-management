namespace SenikWebApi.Models;

public class OrderModel
{
    public string CustomerName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public DateTime? ShippedDate { get; set; }
    public string PaymentMethod { get; set; } = "Momo";

    public ICollection<OrderDetailModel> Products { get; set; } = new List<OrderDetailModel>();
}
