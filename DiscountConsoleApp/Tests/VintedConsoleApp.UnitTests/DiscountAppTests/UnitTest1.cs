using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VintedConsoleApp.Discounts;
using VintedConsoleApp.Models;
using VintedConsoleApp.Services;
using Xunit;

namespace VintedConsoleApp.UnitTests
{
    public class InitiateServiceTests
    {
        [Fact]
        public async Task OutputToConsoleTheSame()
        {
            var providers = new List<ShippingInfo>
            {
                new ShippingInfo() { Provider = "LP", PackageSize = "S", Price = 1.5M },
                new ShippingInfo() { Provider = "LP", PackageSize = "M", Price = 4.9M },
                new ShippingInfo() { Provider = "LP", PackageSize = "L", Price = 6.9M },
                new ShippingInfo() { Provider = "MR", PackageSize = "S", Price = 2M },
                new ShippingInfo() { Provider = "MR", PackageSize = "M", Price = 3M },
                new ShippingInfo() { Provider = "MR", PackageSize = "L", Price = 4M }
            };

            var providersServiceMock = new Mock<IProvidersService>();
            providersServiceMock.Setup(x => x.GetProviders()).Returns(providers);

            var fileService = new FileService(providersServiceMock.Object);
            var discountFactory = new DiscountFactory();
            var calculationService = new CalculationService(discountFactory);
            var printService = new PrintService();

            var initiateService = new InitiateService(fileService, calculationService, printService);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            await initiateService.Initiate();

            Assert.Equal("2015-02-01 S MR 1,50 0,50 \r\n2015-02-02 S MR 1,50 0,50 \r\n2015-02-03 L LP 6,90 - \r\n2015-02-05 S LP 1,50 - \r\n2015-02-06 S MR 1,50 0,50 \r\n2015-02-06 L LP 6,90 - \r\n2015-02-07 L MR 4,00 - \r\n2015-02-08 M MR 3,00 - \r\n2015-02-09 L LP 0,00 6,90 \r\n2015-02-10 L LP 6,90 - \r\n2015-02-10 S MR 1,50 0,50 \r\n2015-02-10 S MR 1,50 0,50 \r\n2015-02-11 L LP 6,90 - \r\n2015-02-12 M MR 3,00 - \r\n2015-02-13 M LP 4,90 - \r\n2015-02-15 S MR 1,50 0,50 \r\n2015-02-17 L LP 6,90 - \r\n2015-02-17 S MR 1,90 0,10 \r\n2015-02-24 L LP 6,90 - \r\n2015-02-29 CUSPS Ignored \r\n2015-03-01 S MR 1,50 0,50 \r\n", stringWriter.ToString());
            // Assert.Equal(File.ReadAllText("WriteLines.txt"), File.ReadAllText("WriteLinesCheck.txt"));
        }
    }
}