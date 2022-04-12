using ShopWebApi.Data;
using ShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>
    {
        public ShopRepository(DataContext context) : base(context)
        {

        }

    }
}
