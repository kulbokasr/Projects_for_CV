using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Discounts.Strategies
{
    public class SmallPackageDiscount : IDiscount
    {
        public (List<ReadAndUpdate>, decimal, int) ApplyDiscount(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, int LpLshipmentCount, decimal minSPrice)
        {
            item.Discount = item.OriginalPrice - minSPrice;
            if (item.Discount < availableDiscount)
            {
                item.DiscountedPrice = item.OriginalPrice - item.Discount;
                availableDiscount -= item.Discount;
            }
            else if (item.Discount > availableDiscount)
            {
                item.DiscountedPrice = item.OriginalPrice - availableDiscount;
                item.Discount = availableDiscount;
                availableDiscount = 0;
            }
            else
            { item.DiscountedPrice = item.OriginalPrice; }
            return (info, availableDiscount, LpLshipmentCount);
        }
    }
}
