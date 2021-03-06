using _1337Corp.PetShopApp.Core.IServices;
using _1337Corp.PetShopApp.Domain.IRepositories;
using _1337Corp.PetShopApp.Domain.Services;
using _1337Corp.PetShopApp.Infrastructure.Data;
using _1337Corp.PetShopApp.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _1337Corp.PetShopApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();

            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();
             serviceCollection.AddScoped<IOwnerService, OwnerService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var petTypeService = serviceProvider.GetRequiredService<IPetTypeService>();
            var ownerService = serviceProvider.GetRequiredService<IOwnerService>();

            var startUp = new Menu(petService, petTypeService, ownerService);
            startUp.Start();
        }
    }
}
