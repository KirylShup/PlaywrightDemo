using Newtonsoft.Json;
using PlayWrightDemo.Utils;

namespace PlayWrightDemo.TestData.Models
{
    public class UserBody : BaseDto
    {
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("defaultPassword", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultPassword { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        public UserBody()
        {
            FirstName = "automationUser" + RandomStringHelper.GetRandomNumericalString(5);
            LastName = "automationUser" + RandomStringHelper.GetRandomNumericalString(5);
            Email = RandomStringHelper.GetRandomAlphanumericalString(8) + "@" + "testing.epam.mail.com";
            Status = "Active";
        }
    }
}
