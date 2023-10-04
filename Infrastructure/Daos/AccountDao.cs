using Domain;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class AccountDao : BaseDao<Account>
{
    public AccountDao(IClaimService claimService) : base(claimService)
    {
    }


}
