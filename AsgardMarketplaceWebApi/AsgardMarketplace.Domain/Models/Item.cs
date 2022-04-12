using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsgardMarketplace.Domain.Models
{
    public class Item : Entity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
