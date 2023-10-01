namespace SenikWebApi.Models;

public class CustomerInforVM
{
    public string FullName { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
}
