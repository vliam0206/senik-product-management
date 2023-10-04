using Domain;
using Infrastructure.IServices;

namespace Infrastructure.Daos;

public class ProductDao : BaseDao<Product>
{
    public ProductDao(IClaimService claimService) : base(claimService)
    {
    }
}
