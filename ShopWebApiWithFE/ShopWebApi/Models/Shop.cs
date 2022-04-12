using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Models
{
    public class Shop : NamedEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<Item> Items { get; set; }
    }
}
