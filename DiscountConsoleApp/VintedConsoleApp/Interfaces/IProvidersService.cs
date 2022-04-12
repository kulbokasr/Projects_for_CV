using VintedConsoleApp.Models;

namespace VintedConsoleApp.Services
{
    public interface IProvidersService
    {
        List<ShippingInfo> GetProviders();
    }
}