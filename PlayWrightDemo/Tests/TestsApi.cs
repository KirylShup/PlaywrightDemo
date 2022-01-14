using FluentAssertions;
using NUnit.Framework;
using PlayWrightDemo.APIRepository.Endpoints;
using PlayWrightDemo.Core;
using PlayWrightDemo.TestData.Models;
using System.Net;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class TestsApi : BaseTestApi
    {
        [Test]
        public void SampleOfAPITest()
        {
            var token = CoreClient.Instance(Configuration.Configuration.AuthUrlStaging).GetM2MToken();
            Assert.IsTrue(token.RestResponse.StatusCode == HttpStatusCode.OK);

            var organization = EntitlementsEndpoint.Instance.CreateOrganization(new OrganizationBody(), token.Body.AccessToken);
            Assert.IsTrue(organization.RestResponse.StatusCode == HttpStatusCode.Created);
            organization.RestResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
