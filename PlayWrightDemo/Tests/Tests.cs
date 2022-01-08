using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlayWrightDemo.Database;
using PlayWrightDemo.Pages;
using System.Linq;
using System.Threading.Tasks;
using PlayWrightDemo.Core;
using System.Net;
using FluentAssertions;
using PlayWrightDemo.TestData;
using PlayWrightDemo.TestData.Models;
using PlayWrightDemo.APIRepository.Endpoints;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class Tests : BaseTestUI
    {
        [Test]
        public async Task SampleOfUITest()
        {
            var user = UserData.GetUser("stagingUser");
            var invitee = new UserBody();
            var loginPage = new LoginPage(page);
            await loginPage.NavigateByURL();
            var usersPage = loginPage.Login(user.Email, user.DefaultPassword).Result;
            await usersPage.InviteNewUser(invitee.FirstName, invitee.LastName, invitee.Email);
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

            var organization = Entitlements.CreateOrganization(new OrganizationBody(), token.Body.AccessToken);
            Assert.IsTrue(organization.RestResponse.StatusCode == HttpStatusCode.Created);
            organization.RestResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
