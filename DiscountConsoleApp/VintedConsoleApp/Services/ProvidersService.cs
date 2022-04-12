using VintedConsoleApp.Models;

namespace VintedConsoleApp.Services
{
    public class ProvidersService : IProvidersService
    {
        public List<ShippingInfo> providers = new List<ShippingInfo>
        {
            new ShippingInfo() { Provider = "LP", PackageSize = "S", Price = 1.5M },
            new ShippingInfo() { Provider = "LP", PackageSize = "M", Price = 4.9M },
            new ShippingInfo() { Provider = "LP", PackageSize = "L", Price = 6.9M },
            new ShippingInfo() { Provider = "MR", PackageSize = "S", Price = 2M },
            new ShippingInfo() { Provider = "MR", PackageSize = "M", Price = 3M },
            new ShippingInfo() { Provider = "MR", PackageSize = "L", Price = 4M }
        };

        public List<ShippingInfo> GetProviders()
        {
            return providers;
        }
    }
}
