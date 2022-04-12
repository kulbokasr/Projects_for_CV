using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Infrastructure.Data;
using AsgardMarketplace.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AsgardMarketplace.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}