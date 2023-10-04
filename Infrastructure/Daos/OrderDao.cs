using DataAccess;
using Domain;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Daos;

public class OrderDao : BaseDao<Order>
{
    public OrderDao(IClaimService claimService) : base(claimService)
    {
    }

    public override async Task<List<Order>> GetAllAsync()
    {
        var dbcontext = new AppDBContext();
        return await dbcontext.Orders
                            .Include(x => x.OrderDetails)
                            .ToListAsync();
    }
}
