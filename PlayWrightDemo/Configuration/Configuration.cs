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

        [JsonProperty("selfServicePortalUrl")]
        public static string SelfServicePortalUrl { get; set; }

        [JsonProperty("entitlementsConnectionString")]
        public static string EntitlementsConnectionString { get; set; }

        [JsonProperty("grantTypeClientCredentials")]
        public static string GrantTypeClientCredentials { get; set; }

        [JsonProperty("grantTypeClientCredentials")]
        public static string GrantTypePasswordFlow { get; set; }

        [JsonProperty("audience")]
        public static string Audience { get; set; }

        [JsonProperty("clientId_BackOffice")]
        public static string ClientIdBackOffice { get; set; }

        [JsonProperty("clientId_TakeoffDesktop")]
        public static string ClientIdTakeoffDesktop { get; set; }

        [JsonProperty("clientSecret_BackOffice")]
        public static string ClientSecretBackOffice { get; set; }

        [JsonProperty("clientSecret_TakeoffDesktop")]
        public static string ClientSecretTakeoffDesktop { get; set; }

        [JsonProperty("authUrlStaging")]
        public static string AuthUrlStaging { get; set; }

        [JsonProperty("entitlementsUrlStaging")]
        public static string EntitlementsUrlStaging { get; set; }

        [JsonProperty("accessManagementUrlStaging")]
        public static string AccessManagementUrlStaging { get; set; }

        [JsonProperty("scope")]
        public static string Scope { get; set; }

        public static void InitiateConfigurationFile()
        {
            var pathToExecutiveDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder().AddJsonFile($"{pathToExecutiveDirectory}" + @"\Configuration\appconfig.json", false, true).Build();
            Browser = config["AppSettings:browser"];
            Environment = config["AppSettings:environment"];
            SelfServicePortalUrl = config["AppSettings:selfServicePortalUrl"];
            EntitlementsConnectionString = config["AppSettings:entitlementsConnectionString"];
            GrantTypeClientCredentials = config["AppSettings:grantTypeClientCredentials"];
            GrantTypePasswordFlow = config["AppSettings:grantTypePasswordFlow"];
            Audience = config["AppSettings:audience"];
            ClientIdBackOffice = config["AppSettings:clientId_BackOffice"];
            ClientSecretBackOffice = config["AppSettings:clientSecret_BackOffice"];
            ClientIdTakeoffDesktop = config["AppSettings:clientId_TakeoffDesktop"];
            ClientSecretTakeoffDesktop = config["AppSettings:clientSecret_TakeoffDesktop"];
            AuthUrlStaging = config["AppSettings:authUrlStaging"];
            EntitlementsUrlStaging = config["AppSettings:entitlementsUrlStaging"];
            AccessManagementUrlStaging = config["AppSettings:accessManagementUrlStaging"];
            Scope = config["AppSettings:scope"];
        }
    }
}
