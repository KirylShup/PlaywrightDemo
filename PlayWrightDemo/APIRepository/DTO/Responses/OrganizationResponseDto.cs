using Newtonsoft.Json;
using System;

namespace PlayWrightDemo.DTO.Responses
{
    public class OrganizationResponseDto : BaseDto
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("organizationId")]
        public Guid OrganizationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("useMFA")]
        public bool UseMfa { get; set; }
    }
}
