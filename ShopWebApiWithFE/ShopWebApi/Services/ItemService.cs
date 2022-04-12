using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data;
using ShopWebApi.Dtos;
using ShopWebApi.Models;
using ShopWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Services
{
    public class ItemService 
    {
        private readonly DataContext _dataContext;
        private ItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(DataContext dataContext, ItemRepository itemRepository, IMapper mapper)
        {
            _dataContext = dataContext;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<List<Item>> GetAllAsync()
        {
            List<Item> items = await _itemRepository.GetAllAsync();
            return items;
        }
        public async Task<Item> GetByIdAsync(int id)
        {
            Item item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Item with such Id does not exist");
            }
            return item;
        }
        public async Task RemoveAsync(int id)
        {
            Item item = await GetByIdAsync(id);
            _dataContext.Items.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<int> CreateAsync(CreateItem createItem)
        {
            bool doesShopExist = await _dataContext.Shops.AnyAsync(x => x.Id == createItem.ShopId);
            if (doesShopExist == false)
            {
                throw new ArgumentException("Cannot assign to this shop as it does not exist");
            }
            var model = new Item();
            model = _mapper.Map<Item>(createItem);
            _dataContext.Items.Add(model);
            await _dataContext.SaveChangesAsync();
            return model.Id;
        }
        public async Task UpdateAsync(int id, UpdateItem updateItem)
        {
            Item item = await GetByIdAsync(id);
            bool doesShopExist = await _dataContext.Shops.AnyAsync(x => x.Id == updateItem.ShopId);
            if (doesShopExist == false)
            {
                throw new ArgumentException("Cannot assign to this shop as it does not exist");
            }
            item.Name = updateItem.Name;
            item.Price = updateItem.Price;
            item.ShopId = updateItem.ShopId;
            await _dataContext.SaveChangesAsync();

        }
    }
}
