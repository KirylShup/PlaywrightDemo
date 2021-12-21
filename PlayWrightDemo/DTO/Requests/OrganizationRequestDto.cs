using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo.DTO.Requests
{
    public class OrganizationRequestDto : BaseDto
    {     
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

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}

