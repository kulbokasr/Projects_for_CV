using AutoMapper;
using ShopWebApi.Dtos;
using ShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Mappers
{
    public class ShopAppMapper : Profile
    {
        public ShopAppMapper()
        {
            CreateMap<CreateShop, Shop>();
            CreateMap<CreateItem, Item>();
        }
    }
}
