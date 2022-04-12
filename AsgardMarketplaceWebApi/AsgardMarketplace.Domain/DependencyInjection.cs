using AsgardMarketplace.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AsgardMarketplace.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<OrderService>();
        }
    }
}