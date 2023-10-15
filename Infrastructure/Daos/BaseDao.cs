using DataAccess;
using Domain;
using Infrastructure.Commons;
using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Daos;

public class BaseDao<T> where T : BaseEntity
{
    private readonly IClaimService _claimService;
    private readonly AppConfiguration _config;
    public BaseDao(IClaimService claimService, AppConfiguration configuration)
    {
        _claimService = claimService;
        _config = configuration;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        var dbcontext = new AppDBContext(_config);
        return await dbcontext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var dbcontext = new AppDBContext(_config);
        return await dbcontext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        entity.CreatedBy = _claimService.GetCurrentUserId;
        var dbcontext = new AppDBContext(_config);
        await dbcontext.Set<T>().AddAsync(entity);
        await dbcontext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedBy = _claimService.GetCurrentUserId;
        }
        var dbcontext = new AppDBContext(_config);
        await dbcontext.Set<T>().AddRangeAsync(entities);
        await dbcontext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entity.ModificationDate = DateTime.Now;
        entity.ModifiedBy = _claimService.GetCurrentUserId;

        var dbcontext = new AppDBContext(_config);
        dbcontext.Entry(entity).State = EntityState.Modified;
        await dbcontext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        var dbcontext = new AppDBContext(_config);
        dbcontext.Set<T>().Remove(entity);
        await dbcontext.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.IsDeleted = true;
        entity.DeletionDate = DateTime.Now;
        entity.DeletedBy = _claimService.GetCurrentUserId;

        var dbcontext = new AppDBContext(_config);
        dbcontext.Entry(entity).State = EntityState.Modified;
        await dbcontext.SaveChangesAsync();
    }
}
