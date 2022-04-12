using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Domain.Models;
using AsgardMarketplace.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateOrderAsync(CreateOrder givenOrder)
        {
            Order order = new Order()
            {
                ItemId = givenOrder.ItemId,
                UserId = givenOrder.UserId
            };
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int id)
        {
            Order order = await _dataContext.Orders.FindAsync(id);
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();
        }
        public async Task ChangeToPaidAsync(int id)
        {
            Order order = await _dataContext.Orders.FindAsync(id);
            order.Status = "Paid";
            await _dataContext.SaveChangesAsync();
        }
        public async Task ChangeToCompletedAsync(int id)
        {
            Order order = await _dataContext.Orders.FindAsync(id);
            order.Status = "Completed";
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<Order>> GetUserOrdersAsync(int userId)
        {
            List<Order> orders = await _dataContext.Orders.Where(x => x.UserId == userId).Include(x=> x.Item).Include(x=> x.User).ToListAsync(); 
            return orders;
        }
    }
}
