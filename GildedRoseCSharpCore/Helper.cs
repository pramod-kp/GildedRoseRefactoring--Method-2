using GildedRoseCSharpCore.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace GildedRoseCSharpCore
{
    public static class Helper
    {
        /// <summary>
        /// Method to register dependecies (services) from the settings file
        /// </summary>
        public static IServiceCollection AddFromConfigurationFile(this IServiceCollection services, IConfigurationSection configuration)
        {
            var servicesConfiguration = configuration.Get<ServicesConfiguration>();

            foreach (var service in servicesConfiguration.Singleton)
            {
                services.AddSingleton(Type.GetType(service.Service), Type.GetType(service.Implementation));
            }

            foreach (var service in servicesConfiguration.Transient)
            {
                services.AddTransient(Type.GetType(service.Service), Type.GetType(service.Implementation));
            }

            //Other scopes here

            return services;
        }

        /// <summary>
        /// Method to get Configuration from settings file
        /// </summary>
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        /// <summary>
        /// Method to handle the global exceptions
        /// </summary>
        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
