using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(CreateOrder givenOrder);
        Task DeleteOrderAsync(int id);
        Task ChangeToPaidAsync(int id);
        Task ChangeToCompletedAsync(int id);
        Task<List<Order>> GetUserOrdersAsync(int userId);

    }
}
