using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRoseCSharpCore.Services
{
    public class UpdateItemStrategyFactory : IUpdateItemStrategyFactory
    {        
        private readonly IServiceProvider serviceProvider;

        public UpdateItemStrategyFactory(IServiceProvider serviceProvider)
        {            
            this.serviceProvider = serviceProvider;
        }

        public IInventoryUpdateStrategy GetStrategy(ItemList item)
        {
            var serviceType = Type.GetType(item.Resolver);
            return (IInventoryUpdateStrategy)serviceProvider.GetRequiredService(serviceType);
        }
    }
}
