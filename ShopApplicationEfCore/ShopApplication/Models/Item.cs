using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required] [MinLength(5)] [MaxLength(15)]
        public string Name { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public DateTime ExpirityDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        [NotMapped]
        public List<Shop> Shops { get; set; }
        public List<ItemTag> ItemTags { get; set; }

    }
}
