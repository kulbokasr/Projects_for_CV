using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Dtos
{
    public class CreateItem
    {
        public double Price { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
    }
}
