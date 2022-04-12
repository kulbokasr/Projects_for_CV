using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.Domain.Models
{
    public class Order : Entity
    {
        public string Status { get; set; } = "Created";
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
