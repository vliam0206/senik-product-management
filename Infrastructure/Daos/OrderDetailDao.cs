using Domain;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class OrderDetailDao : BaseDao<OrderDetail>
{
    public OrderDetailDao(IClaimService claimService) : base(claimService)
    {
    }
}
