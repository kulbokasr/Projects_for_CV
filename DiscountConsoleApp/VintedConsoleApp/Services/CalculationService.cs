using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Discounts;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Services
{
    public class CalculationService
    {
        //https://refactoring.guru/design-patterns/factory-method/csharp/example
        //https://codewithshadman.com/strategy-pattern-csharp/

        private DiscountFactory _discountFactory;

        public CalculationService(DiscountFactory discountFactory)
        {
            _discountFactory = discountFactory;
        }

        public List<ReadAndUpdate> Calculate(List<ReadAndUpdate> info)
        {
            var minSPrice = info.Where(p => p.PackageSize == "S").Min(p => p.OriginalPrice);
            decimal availableDiscount = 10;
            var LpLshipmentCount = 0;

            foreach (var item in info)
            {

                (info, availableDiscount, LpLshipmentCount) = CheckIfMonthChange(item, info, availableDiscount, LpLshipmentCount);

                //if (item.PackageSize == "S" && item.OriginalPrice > minSPrice)
                //{
                //    (info, availableDiscount) = PackageSDiscount(item, info, availableDiscount, minSPrice);
                //}
                //else if (item.PackageSize == "L" && item.Provider == "LP")
                //{
                //    (info, availableDiscount, LpLshipmentCount) = PackageLDiscount(item, info, availableDiscount, LpLshipmentCount);
                //}
                //else
                //{
                //    item.DiscountedPrice = item.OriginalPrice;
                //}

                try
                {
                    (info, availableDiscount, LpLshipmentCount) = _discountFactory.ChooseDiscount(item, minSPrice).ApplyDiscount(item, info, availableDiscount, LpLshipmentCount, minSPrice);
                }
                catch
                {
                    item.DiscountedPrice = item.OriginalPrice;
                }
            }
            return info;
        }

        private (List<ReadAndUpdate>, decimal, int) CheckIfMonthChange(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, int LpLshipmentCount)
        {
            var itemIndex = info.IndexOf(item);
            if (itemIndex - 1 < 0)
            {
                itemIndex++;
            };

            if (info[itemIndex].Date.Month != info[itemIndex - 1].Date.Month)
            {
                availableDiscount = 10;
                LpLshipmentCount = 0;
            }
            return (info, availableDiscount, LpLshipmentCount);
        }

        //private (List<ReadAndUpdate>, decimal) PackageSDiscount(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, decimal minSPrice)
        //{
        //    item.Discount = item.OriginalPrice - minSPrice;
        //    if (item.Discount < availableDiscount)
        //    {
        //        item.DiscountedPrice = item.OriginalPrice - item.Discount;
        //        availableDiscount -= item.Discount;
        //    }
        //    else if (item.Discount > availableDiscount)
        //    {
        //        item.DiscountedPrice = item.OriginalPrice - availableDiscount;
        //        item.Discount = availableDiscount;
        //        availableDiscount = 0;
        //    }
        //    else
        //    { item.DiscountedPrice = item.OriginalPrice; }
        //    return (info, availableDiscount);
        //}
        //private (List<ReadAndUpdate>, decimal, int) PackageLDiscount(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, int LpLshipmentCount)
        //{
        //    LpLshipmentCount++;
        //    item.DiscountedPrice = item.OriginalPrice;
        //    if (LpLshipmentCount == 3)
        //    {
        //        item.Discount = item.OriginalPrice;
        //        item.DiscountedPrice = 0;
        //        availableDiscount -= item.Discount;
        //    }
        //    return (info, availableDiscount, LpLshipmentCount);
        //}
    }
}
