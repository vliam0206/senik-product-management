using Domain;

namespace SenikWebApi.Models;

public class AccountVM : BaseEntity
{    
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string Role { get; set; } = default!;
}
