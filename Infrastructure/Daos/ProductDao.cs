using Domain;
using Infrastructure.Commons;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class ProductDao : BaseDao<Product>
{
    public ProductDao(IClaimService claimService,
            AppConfiguration configuration) : base(claimService, configuration)
    {
    }
}
