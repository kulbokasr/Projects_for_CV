using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Discounts.Strategies
{
    public class LargerPackageDiscount : IDiscount
    {
        public (List<ReadAndUpdate>, decimal, int) ApplyDiscount(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, int LpLshipmentCount, decimal minSPrice)
        {
            LpLshipmentCount++;
            item.DiscountedPrice = item.OriginalPrice;
            if (LpLshipmentCount == 3)
            {
                item.Discount = item.OriginalPrice;
                item.DiscountedPrice = 0;
                availableDiscount -= item.Discount;
            }
            return (info, availableDiscount, LpLshipmentCount);
        }
    }
}
