using PlayWrightDemo.APIRepository.DTO;
using PlayWrightDemo.Core;
using System.Collections.Generic;

namespace PlayWrightDemo.APIRepository.Endpoints
{
    public class AccessManagement : BaseEndpoint
    {
        private static string URL => "https://api-staging.app.constructconnect.com/accessmanagement/v1.0"; //harcode, replace with config file later
        private static AccessManagement accessManagement;

        public static new AccessManagement Instance => accessManagement ?? (accessManagement = new AccessManagement());

        public Response<List<GetRolesInMyOrgDto>> GetRolesInMyOrg (string userToken)
        {
            return CoreClient.Instance(URL + @"/my/organization/roles").Get<List<GetRolesInMyOrgDto>>(useToken: true, authorizationToken: userToken);
        }
    }
}
