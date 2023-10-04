using Domain;

namespace Infrastructure.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<List<Account>> GetAllAccountsAsync();
    Task<Account?> GetAccountByEmailAsync(string email);
}
