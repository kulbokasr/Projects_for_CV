using ShopWebApi.Data;
using ShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Repositories
{
    public class ItemRepository : RepositoryBase<Item>
    {
        public ItemRepository(DataContext context) : base(context)
        {

        }

    }
}