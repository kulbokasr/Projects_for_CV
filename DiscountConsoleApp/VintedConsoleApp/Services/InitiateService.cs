using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VintedConsoleApp.Models;

namespace VintedConsoleApp.Services
{
    public class InitiateService
    {
        private FileService _fileService;
        private CalculationService _calculationService;
        private PrintService _printService;

        public InitiateService(FileService fileService, CalculationService calculationService, PrintService printService)
        {
            _fileService = fileService;
            _calculationService = calculationService;
            _printService = printService;
        }

        public async Task Initiate()
        {
            var allinfo = await _fileService.ReadFileAsync();
            var calculatedInfo = _calculationService.Calculate(allinfo);
            _printService.PrintToConsole(calculatedInfo);
            _printService.PrintToFile(calculatedInfo);
        }
    }
}
