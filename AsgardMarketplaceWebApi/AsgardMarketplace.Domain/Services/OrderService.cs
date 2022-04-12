using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task CreateOrderAsync(CreateOrder givenOrder)
        {
            await _orderRepository.CreateOrderAsync(givenOrder);
        }
        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
        public async Task ChangeToPaidAsync(int id)
        {
            await _orderRepository.ChangeToPaidAsync(id);
        }
        public async Task ChangeToCompletedAsync(int id)
        {
            await _orderRepository.ChangeToCompletedAsync(id);
        }
        public async Task<List<Order>> GetUserOrdersAsync(int userId)
        {
            return await _orderRepository.GetUserOrdersAsync(userId);
        }
    }
}
