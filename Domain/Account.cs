using Domain.Enums;

namespace Domain;

public class Account : BaseEntity
{    
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public AccountTypeEnum Role { get; set; } = AccountTypeEnum.Customer;

    public int? CustomerId { get; set; }
    public CustomerInfor? CustomerInfor { get; set; }
}
