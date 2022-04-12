using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Models
{
    public class Item : NamedEntity
    {
        public double Price { get; set; }
        public int ShopId { get; set; }
    }
}
