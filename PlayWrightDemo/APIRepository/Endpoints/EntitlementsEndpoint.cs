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
            return CoreClient.Instance().Post<OrganizationResponseDto>(URL + @"/organizations", body, useToken: true, authorizationToken: token);
        }

        public Response<OrganizationResponseDto> GetOrganizationById(string orgId, string token)
        {
            return CoreClient.Instance().Get<OrganizationResponseDto>(URL + @$"/organizations/{orgId}", useToken: true, authorizationToken: token);
        }
    }
}
