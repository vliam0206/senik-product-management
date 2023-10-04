using Domain;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class OrderDao : BaseDao<Order>
{
    public OrderDao(IClaimService claimService) : base(claimService)
    {
    }
}
