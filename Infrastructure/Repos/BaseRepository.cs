using DataAccess;
using Domain;
using Infrastructure.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDBContext _dbContext;
    public BaseRepository(AppDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
