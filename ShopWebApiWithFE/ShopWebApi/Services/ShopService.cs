using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data;
using ShopWebApi.Dtos;
using ShopWebApi.Exeptions;
using ShopWebApi.Models;
using ShopWebApi.Repositories;
using ShopWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Services
{
    public class ShopService
    {
        private readonly DataContext _dataContext;
        private ShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(DataContext dataContext, ShopRepository shopRepository, IMapper mapper)
        {
            _dataContext = dataContext;
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
        public async Task<List<Shop>> GetAllAsync()
        {
            List<Shop> shops = await _dataContext.Shops.Include("Items").ToListAsync();
            return shops;
        }
        public async Task<Shop> GetByIdAsync(int id)
        {
            var shop = await _dataContext.Shops.Include("Items").Where(i=> i.Id == id).FirstOrDefaultAsync();
            if (shop == null)
            {
                throw new IdException(id);
            }
            return shop;
        }
        public async Task RemoveAsync(int id)
        {
            Shop shop = await GetByIdAsync(id);
            _dataContext.Shops.Remove(shop);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<int> CreateAsync(CreateShop createShop)
        {
            bool doesNameExist = await _dataContext.Shops.AnyAsync(x => x.Name == createShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("Shop with such name already exists");
            }
            ShopValidator validator = new ShopValidator();
            await validator.ValidateAndThrowAsync(createShop);
            var model = new Shop();
            model = _mapper.Map<Shop>(createShop);
            _dataContext.Shops.Add(model);
            await _dataContext.SaveChangesAsync();
            return model.Id;
        }
        public async Task UpdateAsync(int id, UpdateShop updateShop)
        {
            Shop shop = await GetByIdAsync(id);
            bool doesNameExist = await _dataContext.Shops.AnyAsync(x => x.Name == updateShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("Shop with such name already exists");
            }
           shop.Name = updateShop.Name;
            await _dataContext.SaveChangesAsync();

        }
    }
}
