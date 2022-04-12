using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Dtos;
using ShopWebApi.Services;
using ShopWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _itemService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _itemService.GetByIdAsync(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateItem createItem)
        {
            ItemValidator validator = new ItemValidator();
            ValidationResult results = validator.Validate(createItem);
            if (!results.IsValid)
            {
                return BadRequest(results.ToString("-"));
            }
            try
            {
                int createdItemId = await _itemService.CreateAsync(createItem);
                return Created("", createdItemId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateItem updateItem)
        {
            UpdateItemValidator validator = new UpdateItemValidator();
            ValidationResult results = validator.Validate(updateItem);
            if (!results.IsValid)
            {
                return BadRequest(results.ToString("-"));
            }
            try
            {
                await _itemService.UpdateAsync(id, updateItem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Item Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _itemService.RemoveAsync(id);
                return Ok("Item deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
