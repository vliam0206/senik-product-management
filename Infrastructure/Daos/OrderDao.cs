using DataAccess;
using Domain;
using Infrastructure.IServices;
using Microsoft.AspNetCore.JsonPatch;
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
                            .ThenInclude(d => d.Product)
                            .ToListAsync();
    }

    public async Task PatchUpdateAsync(int orderId, JsonPatchDocument<Order> orderModel)
    {
        try
        {
            var dbcontext = new AppDBContext();
            var order = await dbcontext.Orders.FindAsync(orderId);
            if (order != null)
            {
                orderModel.ApplyTo(order);
                await dbcontext.SaveChangesAsync();
            }
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
