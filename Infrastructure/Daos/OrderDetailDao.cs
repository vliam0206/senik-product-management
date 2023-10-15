using Domain;
using Infrastructure.Commons;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class OrderDetailDao : BaseDao<OrderDetail>
{
    public OrderDetailDao(IClaimService claimService,
            AppConfiguration configuration) : base(claimService, configuration)
    {
    }
}
