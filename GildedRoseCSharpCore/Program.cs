using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseCSharpCore
{
    public class Program
    {        
        public IList<ItemList> Items;
        private IUpdateItemStrategyFactory _updateStrategy;

        public Program(IUpdateItemStrategyFactory updateStrategy, List<ItemList> items)
        {
            _updateStrategy = updateStrategy;
            Items = items;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");
            // register exception handler
            AppDomain.CurrentDomain.UnhandledException += Helper.UnhandledExceptionTrapper;

            IServiceCollection serviceCollection = new ServiceCollection();
            IConfigurationRoot configuration = Helper.GetConfiguration();            

            List<ItemList> items = new List<ItemList>();
            configuration.GetSection("Inventory").Bind(items);
            
            // register services / dependencies
            serviceCollection.AddFromConfigurationFile(configuration.GetSection("Services"));                        
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var updateStrategy = serviceProvider.GetService<IUpdateItemStrategyFactory>();
            var app = new Program(updateStrategy, items);            

            app.UpdateInventory();

            Console.ReadKey();
            app.DisposeServices(serviceCollection);
        }

        public void UpdateInventory()
        {
            foreach (var item in Items)
            {
                var strategy = _updateStrategy.GetStrategy(item);
                strategy.UpdateItem(item);
            }
        }

        private void DisposeServices(IServiceCollection services)
        {
            foreach (var service in services)
            {
                if (service == null)
                    return;
                if (service is IDisposable)
                    ((IDisposable)service).Dispose();
            }
        }
    }
}
