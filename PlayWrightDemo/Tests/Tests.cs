using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlayWrightDemo.Database;
using PlayWrightDemo.Pages;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using PlayWrightDemo.Core;
using System.Net;
using PlayWrightDemo.DTO.Responses;
using PlayWrightDemo.DTO.Requests;
using FluentAssertions;
using PlayWrightDemo.TestData;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public async Task SampleOfUITest()
        {
            var user = UserData.GetUser("stagingUser");
            var loginPage = new LoginPage(page);
            await loginPage.NavigateByURL();
            var usersPage = loginPage.Login(user.Email, user.DefaultPassword).Result;
            await usersPage.InviteNewUser("Kiryl", "Shupenich", "ks_playwright_test4@mailinator.com");
            using var dbContext = new EntitlementsContext(entitlementsConnectionString);
            var userRecord = dbContext.User.Include(u => u.InvitationToJoin).Where(x => x.EmailAddress == user.Email).FirstOrDefault();
            var organizationRecord = dbContext.Organization.Include(x => x.User).Where(x => x.OrganizationID == userRecord.OrganizationID).FirstOrDefault();
            var organizationModuleRecord = dbContext.OrganizationModule.Include(x => x.Organization).Where(x => x.OrganizationID == organizationRecord.OrganizationID).FirstOrDefault();
            Assert.NotNull(organizationModuleRecord);
        }

        [Test]
        public void SampleOfAPITest()
        {
            var token = CoreClient.Instance(Configuration.Configuration.AuthUrlStaging).GetM2MToken();
            Assert.IsTrue(token.RestResponse.StatusCode == HttpStatusCode.OK);

            var dto = new OrganizationRequestDto
            {
                Name = "ApiTestinOrg",
                Address = "1916 Central Parkway",
                Status = "Active",
                City = "Cincinnati",
                Country = "US",
                Zip = "45202",
                Phone = "8324431463",
                State = "OH"
            };
            var organization = CoreClient.Instance(Configuration.Configuration.EntitlementsUrlStaging + @"/organizations").Post<OrganizationResponseDto>(dto, true, token.Body.AccessToken);
            Assert.IsTrue(organization.RestResponse.StatusCode == HttpStatusCode.Created);
            organization.RestResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
