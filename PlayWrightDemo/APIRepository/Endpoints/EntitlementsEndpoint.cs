using PlayWrightDemo.Core;
using PlayWrightDemo.DTO.Responses;

namespace PlayWrightDemo.APIRepository.Endpoints
{
    public class EntitlementsEndpoint : BaseEndpoint
    {
        private static string URL => Configuration.Configuration.EntitlementsUrlStaging;
        private static EntitlementsEndpoint entitlements;

        public static new EntitlementsEndpoint Instance => entitlements ?? (entitlements = new EntitlementsEndpoint());

        public Response<OrganizationResponseDto> CreateOrganization(BaseDto body, string token)
        {
            return CoreClient.Instance(URL + @"/organizations").Post<OrganizationResponseDto>(body, useToken: true, authorizationToken: token);
        }

        public Response<OrganizationResponseDto> GetOrganizationById(string orgId, string token)
        {
            return CoreClient.Instance(URL + @$"/organizations/{orgId}").Get<OrganizationResponseDto>(useToken: true, authorizationToken: token);
        }
    }
}
