using Domain;

namespace Infrastructure.IRepos;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
