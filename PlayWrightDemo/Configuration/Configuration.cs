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

        [JsonProperty("grantType")]
        public static string GrantType { get; set; }

        [JsonProperty("audience")]
        public static string Audience { get; set; }

        [JsonProperty("clientId_BackOffice")]
        public static string ClientIdBackOffice { get; set; }

        [JsonProperty("clientSecret_BackOffice")]
        public static string ClientSecretBackOffice { get; set; }


        public static void InitiateConfigurationFile()
        {
            var pathToExecutiveDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder().AddJsonFile($"{pathToExecutiveDirectory}" + @"\Configuration\appconfig.json", false, true).Build();
            Browser = config["AppSettings:browser"];
            Environment = config["AppSettings:environment"];
            Url = config["AppSettings:url"];
            EntitlementsConnectionString = config["AppSettings:entitlementsConnectionString"];
            GrantType = config["AppSettings:grantType"];
            Audience = config["AppSettings:audience"];
            ClientIdBackOffice = config["AppSettings:clientId_BackOffice"];
            ClientSecretBackOffice = config["AppSettings:clientSecret_BackOffice"];
        }
    }
}
