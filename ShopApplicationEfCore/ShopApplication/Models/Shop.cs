using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public bool IsDeleted { get; set; }
    }
}
