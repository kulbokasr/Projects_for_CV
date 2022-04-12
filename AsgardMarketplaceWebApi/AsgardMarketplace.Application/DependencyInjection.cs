using AsgardMarketplace.Domain;
using AsgardMarketplace.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsgardMarketplace.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.RegisterDomain();
            serviceCollection.RegisterDatabase(connectionString);
        }
    }
}