using Domain.Enums;

namespace Domain;

public class Account : BaseEntity
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;    
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public AccountTypeEnum Role { get; set; } = AccountTypeEnum.Customer; // Staff, Customer

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
