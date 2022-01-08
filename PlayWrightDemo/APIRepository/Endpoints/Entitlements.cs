using PlayWrightDemo.Core;
using PlayWrightDemo.DTO.Responses;

namespace PlayWrightDemo.APIRepository.Endpoints
{
    public static class Entitlements
    {
        private static string baseURL => Configuration.Configuration.EntitlementsUrlStaging;

        public static Response<OrganizationResponseDto> CreateOrganization(BaseDto body, string token)
        {
            return CoreClient.Instance(baseURL + @"/organizations").Post<OrganizationResponseDto>(body, true, token);
        }
    }
}
