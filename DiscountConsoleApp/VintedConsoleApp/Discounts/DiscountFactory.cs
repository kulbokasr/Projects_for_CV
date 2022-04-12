using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Discounts.Strategies;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Discounts
{
    public class DiscountFactory
    {
        public IDiscount ChooseDiscount(ReadAndUpdate item, decimal minSPrice)
        {
            if (item.PackageSize == "S" && item.OriginalPrice > minSPrice)
            {
                return new SmallPackageDiscount();
            }
            if (item.PackageSize == "L" && item.Provider == "LP")
            {
                return new LargerPackageDiscount();
            }
            throw new Exception();
        }
    }
}
