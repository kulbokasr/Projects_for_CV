using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Services
{
    public class PrintService
    {
        public void PrintToConsole(List<ReadAndUpdate> info)
        {
            foreach (var item in info)
            {
                if (item.IsError)
                {
                    Console.WriteLine(item.ErrorLine);
                    continue;
                }
                Console.WriteLine($"{item.Date} {item.PackageSize} {item.Provider} {item.DiscountedPrice.ToString("0.00")} " +
                    $"{(item.Discount == 0 ? "-" : item.Discount.ToString("0.00"))} ");
            }
        }
        public void PrintToFile(List<ReadAndUpdate> info)
        {
            foreach (var item in info)
            {
                if (item.IsError)
                {
                    File.AppendAllText("WriteLines.txt", ($"{item.ErrorLine}\r\n"));
                    continue;
                }
                File.AppendAllText("WriteLines.txt", ($"{item.Date} {item.PackageSize} {item.Provider} {item.DiscountedPrice.ToString("0.00")} " +
                    $"{(item.Discount == 0 ? "-" : item.Discount.ToString("0.00"))} \r\n "));
            }
        }
    }
}
