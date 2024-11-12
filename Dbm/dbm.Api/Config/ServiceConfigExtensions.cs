using dbm.Api.Repositories;
using dbm.Api.Repositories.Interfaces;
using dbm.Api.Services;
using dbm.Api.Services.Interfaces;

namespace dbm.Api.Config;

public static class ServiceConfigExtensions
{
    public static void AddScopeds(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddSignalR();

        #region services
        services.AddScoped<IProductService, ProductService>();
        #endregion

        #region repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion
    }
}
