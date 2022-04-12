using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Dtos;
using ShopWebApi.Services;
using ShopWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ShopWebApi.Exeptions;
using FluentValidation;

namespace ShopWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shopService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _shopService.GetByIdAsync(id));
            }
            catch (IdException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateShop createShop)
        {
            try
            {
                int createdShopId = await _shopService.CreateAsync(createShop);
                return Created("", createdShopId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateShop updateShop)
        {
            UpdateShopValidator validator = new UpdateShopValidator();
            ValidationResult results = validator.Validate(updateShop);
            if (!results.IsValid)
            {
                return BadRequest(results.ToString("-"));
            }
            try
            {
                await _shopService.UpdateAsync(id, updateShop);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IdException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok("Shop Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _shopService.RemoveAsync(id);
                return Ok("Shop deleted");
            }
            catch (IdException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
