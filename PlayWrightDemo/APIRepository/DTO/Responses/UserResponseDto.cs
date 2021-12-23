using Newtonsoft.Json;
using System;

namespace PlayWrightDemo.DTO.Responses
{
    public class UserResponseDto
    {
        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("authId")]
        public string AuthId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonProperty("roles")]
        public Role Role { get; set; }
    }

    public class Role
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}