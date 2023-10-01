using DataAccess;
using Domain;
using Infrastructure.IRepos;

namespace Infrastructure.Repos;

public class CustomerInforRepository : BaseRepository<CustomerInfor>, ICustomerInforRepository
{
    private readonly AppDBContext _dbContext;
    public CustomerInforRepository(AppDBContext dBContext) : base(dBContext)
    {
        _dbContext = dBContext;
    }
}
