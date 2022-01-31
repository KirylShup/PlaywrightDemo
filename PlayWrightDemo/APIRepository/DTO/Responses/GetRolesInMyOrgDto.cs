using Newtonsoft.Json;

namespace PlayWrightDemo.APIRepository.DTO
{
    public class GetRolesInMyOrgDto : BaseDto
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("isHidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsHidden { get; set; }

        [JsonProperty("assignedUsers", NullValueHandling = NullValueHandling.Ignore)]
        public int AssignedUsers { get; set; }

        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public int Order { get; set; }
    }
}