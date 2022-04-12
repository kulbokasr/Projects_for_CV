// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using VintedConsoleApp;
using VintedConsoleApp.Models;
using VintedConsoleApp.Services;

var services = new ServiceCollection();

services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

var initiateService = serviceProvider.GetService<InitiateService>();

await initiateService.Initiate();