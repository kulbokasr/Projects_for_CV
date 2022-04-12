using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VintedConsoleApp.Models
{
    public class ReadAndUpdate
    {
        public DateOnly Date { get; set; }
        public string PackageSize { get; set; }
        public string Provider { get; set; }
        public string ErrorLine { get; set; }
        public bool IsError { get; set; } = false;
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
