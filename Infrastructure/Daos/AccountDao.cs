using DataAccess;
using Domain;
using Infrastructure.Commons;
using Infrastructure.IServices;
using Microsoft.AspNetCore.JsonPatch;

namespace Infrastructure.Daos;

public class AccountDao : BaseDao<Account>
{
    private readonly AppConfiguration _config;
    public AccountDao(IClaimService claimService, 
            AppConfiguration configuration) : base(claimService, configuration)
    {
        _config = configuration;
    }

    public async Task PatchUpdateAsync(int accountId, JsonPatchDocument<Account> accountModel)
    {
        try
        {
            var dbcontext = new AppDBContext(_config);
            var account = await dbcontext.Accounts.FindAsync(accountId);
            if (account != null)
            {
                accountModel.ApplyTo(account);
                await dbcontext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
