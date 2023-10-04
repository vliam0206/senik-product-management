using DataAccess;
using Domain;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    private readonly AppDBContext _dbContext;
    public AccountRepository(AppDBContext dBContext) : base(dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<List<Account>> GetAllAccountsAsync()
    {
        return await _dbContext.Accounts.ToListAsync();
    }
}
