using Domain;

namespace Infrastructure.IRepos;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<List<Account>> GetAllAccountsAsync();
    Task<Account?> GetAccountByEmailAsync (string email);
}
