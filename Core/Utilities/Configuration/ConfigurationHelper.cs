using Core.Extensions;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Utilities.Configuration
{
    public class ConfigurationHelper
    {
        public static IConfiguration GetConfig(string jsonFileName = "appsettings")
        {
            if (jsonFileName.IsNullOrWhiteSpace() || jsonFileName.EndsWith(".json"))
                throw new ArgumentException();

            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"{jsonFileName}.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
