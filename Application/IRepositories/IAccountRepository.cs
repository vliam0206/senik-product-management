using Domain;

namespace Infrastructure.Interfaces;

public interface IAccountRepository
{
    Task<List<Account>> GetAllAccountsAsync();
    Task<Account?> GetAccountByEmailAsync(string email);
    Task<Account?> GetAccountByIdAsync(int accountId);
    Task AddAccountAsync(Account account);
    Task UpdateAccountAsync(Account account);
    Task DeleteAccountAsync(int accountId);
}
