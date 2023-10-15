using DataAccess;
using Domain;
using Infrastructure.Commons;
using Infrastructure.IServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Daos;

public class OrderDao : BaseDao<Order>
{
    private readonly AppConfiguration _config;
    public OrderDao(IClaimService claimService,
            AppConfiguration configuration) : base(claimService, configuration)
    {
        _config = configuration;
    }

    public override async Task<List<Order>> GetAllAsync()
    {
        var dbcontext = new AppDBContext(_config);
        return await dbcontext.Orders
                            .Include(x => x.OrderDetails)
                            .ThenInclude(d => d.Product)
                            .ToListAsync();
    }

    public async Task PatchUpdateAsync(int orderId, JsonPatchDocument<Order> orderModel)
    {
        try
        {
            var dbcontext = new AppDBContext(_config);
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
