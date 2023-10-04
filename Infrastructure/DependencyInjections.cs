using Infrastructure.Daos;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddDaoDIs(this IServiceCollection services)
    {
        services.AddSingleton<AccountDao>();
        services.AddSingleton<OrderDao>();
        services.AddSingleton<OrderDetailDao>();
        services.AddSingleton<ProductDao>();

        return services;
    }
}
