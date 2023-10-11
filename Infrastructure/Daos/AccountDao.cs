using DataAccess;
using Domain;
using Infrastructure.IServices;
using Microsoft.AspNetCore.JsonPatch;

namespace Infrastructure.Daos;

public class AccountDao : BaseDao<Account>
{
    public AccountDao(IClaimService claimService) : base(claimService)
    {
    }

    public async Task PatchUpdateAsync(int accountId, JsonPatchDocument<Account> accountModel)
    {
        try
        {
            var dbcontext = new AppDBContext();
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
