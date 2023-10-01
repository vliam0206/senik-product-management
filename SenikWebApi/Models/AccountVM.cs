using Domain;
using Domain.Enums;

namespace SenikWebApi.Models;

public class AccountVM
{
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;
    public CustomerInforVM? Informations { get; set; }
}
