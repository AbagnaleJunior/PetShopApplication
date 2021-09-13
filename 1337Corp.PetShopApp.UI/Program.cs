using _1337Corp.PetShopApp.Core.IServices;
using _1337Corp.PetShopApp.Domain.IRepositories;
using _1337Corp.PetShopApp.Domain.Services;
using _1337Corp.PetShopApp.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _1337Corp.PetShopApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetShopRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
          
            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IPetService>();
            var menu = new Menu(service);
            menu.Start();
        }
    }
}
