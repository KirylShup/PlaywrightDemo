using PlayWrightDemo.Core;
using PlayWrightDemo.DTO.Responses;

namespace PlayWrightDemo.APIRepository.Endpoints
{
    public class EntitlementsEndpoint : BaseEndpoint
    {
        private static string baseURL => Configuration.Configuration.EntitlementsUrlStaging;
        private static EntitlementsEndpoint entitlements;

        public static new EntitlementsEndpoint Instance => entitlements ?? (entitlements = new EntitlementsEndpoint());

        public Response<OrganizationResponseDto> CreateOrganization(BaseDto body, string token)
        {
            return CoreClient.Instance(baseURL + @"/organizations").Post<OrganizationResponseDto>(body, true, token);
        }
    }
}
