namespace Domain;

public class CustomerInfor : BaseEntity
{
    public string FullName { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = default!;
}
