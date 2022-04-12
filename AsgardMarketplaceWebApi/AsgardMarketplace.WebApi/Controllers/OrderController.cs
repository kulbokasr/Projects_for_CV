using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Models;
using AsgardMarketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUsersOrders(int userId)
        {
            return Ok(await _orderService.GetUserOrdersAsync(userId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrder givenOrder)
        {
            await _orderService.CreateOrderAsync(givenOrder);
            return Ok();
        }
        [HttpPut]
        [Route("{id}/Pay")]
        public async Task<IActionResult> ChangeToPaidAsync(int id)
        {
            await _orderService.ChangeToPaidAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("{id}/Complete")]
        public async Task<IActionResult> ChangeToCompletedAsync(int id)
        {
            await _orderService.ChangeToCompletedAsync(id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
