using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Dtos
{
    public class CreateItem
    {
        public Item Item { get; set; } //Not a good practice
        public List<Shop> AllShops { get; set; }
        public List<int> SelectedTagIds { get; set; }  // will contains info on selected tags
        public List<Tag> Tags { get; set; } //Tags to display
    }
}
