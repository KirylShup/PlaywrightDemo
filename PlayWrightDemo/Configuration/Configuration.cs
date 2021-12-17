using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;

namespace PlayWrightDemo.Configuration
{
    public static class Configuration
    {
        [JsonProperty("browser")]
        public static string Browser { get; set; }

        [JsonProperty("environment")]
        public static string Environment { get; set; }

        [JsonProperty("url")]
        public static string Url { get; set; }

        [JsonProperty("entitlementsConnectionString")]
        public static string EntitlementsConnectionString { get; set; }


        public static void InitiateConfigurationFile()
        {
            var pathToExecutiveDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder().AddJsonFile($"{pathToExecutiveDirectory}" + @"\Configuration\appconfig.json", false, true).Build();
            Browser = config["AppSettings:browser"];
            Environment = config["AppSettings:environment"];
            Url = config["AppSettings:url"];
            EntitlementsConnectionString = config["AppSettings:entitlementsConnectionString"];
        }
    }
}
