using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Discounts
{
    public interface IDiscount
    {
        (List<ReadAndUpdate>, decimal, int) ApplyDiscount(ReadAndUpdate item, List<ReadAndUpdate> info, decimal availableDiscount, int LpLshipmentCount, decimal minSPrice);
    }
}
