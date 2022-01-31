using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PlayWrightDemo.APIRepository.Endpoints;
using PlayWrightDemo.Core;
using PlayWrightDemo.TestData;
using PlayWrightDemo.TestData.Models;
using PlayWrightDemo.Utils;
using System.Net;


namespace PlayWrightDemo.Tests
{
    [TestFixture]
    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
    public class TestsApi : BaseTestApi
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void SampleOfApiTestForEntitlements()
        {
            var token = CoreClient.Instance(Configuration.Configuration.AuthUrlStaging).GetM2MToken();
            Assert.IsTrue(token.RestResponse.StatusCode == HttpStatusCode.OK);

            var organization = EntitlementsEndpoint.Instance.CreateOrganization(new OrganizationBody(), token.Body.AccessToken);
            Assert.IsTrue(organization.RestResponse.StatusCode == HttpStatusCode.Created);
            organization.RestResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var returnedOrganization = EntitlementsEndpoint.Instance.GetOrganizationById(organization.Body.OrganizationId.ToString(), token.Body.AccessToken);
            Assert.IsTrue(returnedOrganization.RestResponse.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        [AllureSeverity(SeverityLevel.blocker)]
        public void SampleOfApiTestForAccessManagement()
        {
            var user = UserData.GetUser("stagingUser");
            var token = CoreClient.Instance(Configuration.Configuration.AuthUrlStaging).GetUserToken(user.Email, user.DefaultPassword);
            var response = Attempts.TryUntil(() =>
            {
                return AccessManagement.Instance.GetRolesInMyOrg(token.Body.AccessToken);
            }, _ => _.RestResponse.StatusCode == HttpStatusCode.OK, 1000, 5000);

            Assert.IsTrue(response.RestResponse.StatusCode == HttpStatusCode.OK);
        }
    }
}
