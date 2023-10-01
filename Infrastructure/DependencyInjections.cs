using Infrastructure.IRepos;
using Infrastructure.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddRepositoryDIs(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerInforRepository, CustomerInforRepository>();

        return services;
    }
}
