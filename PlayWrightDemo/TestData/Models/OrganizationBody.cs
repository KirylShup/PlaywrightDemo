using Newtonsoft.Json;
using PlayWrightDemo.Utils;

namespace PlayWrightDemo.TestData.Models
{
    public class OrganizationBody : BaseDto
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        public OrganizationBody()
        {
            Name = RandomHelper.GetRandomAlphanumericalString(30) + "_auomation";
            Status = "Active";
            Address = RandomHelper.GetRandomAlphanumericalString(20) + "_automation";
            City = "Orlando";
            State = "Florida";
            Zip = "10074";
            Phone = "";
            Country = "US";
        }
    }
}
