using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Discounts;
using VintedConsoleApp.Services;

namespace VintedConsoleApp
{
    public static class DependencyInjection
    {
        // Extension methods

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<FileService>();
            services.AddTransient<InitiateService>();
            services.AddTransient<IProvidersService, ProvidersService>();
            services.AddTransient<ProvidersService>();
            services.AddTransient<CalculationService>();
            services.AddTransient<PrintService>();
            services.AddTransient<DiscountFactory>();
        }

    }
}
