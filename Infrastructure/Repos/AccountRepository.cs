using DataAccess;
using Domain;
using Infrastructure.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

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
        return await _dbContext.Accounts.Include(x => x.CustomerInfor).ToListAsync();
    }
}
