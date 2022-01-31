using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlayWrightDemo.Database;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using PlayWrightDemo.TestData;
using PlayWrightDemo.TestData.Models;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

[assembly: LevelOfParallelism(2)]
namespace PlayWrightDemo.Tests
{
    [TestFixture]
    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
    public class TestsUi : BaseTestUi
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task SampleOfUITest()
        {
            var user = UserData.GetUser("stagingUser");
            var invitee = new UserBody();
            await loginPage.NavigateByURL();
            var usersPage = loginPage.Login(user.Email, user.DefaultPassword).Result;
            await usersPage.InviteNewUser(invitee.FirstName, invitee.LastName, invitee.Email);
            using var dbContext = new EntitlementsContext(entitlementsConnectionString);
            var userRecord = dbContext.User.Include(u => u.InvitationToJoin).Where(x => x.EmailAddress == user.Email).FirstOrDefault();
            var organizationRecord = dbContext.Organization.Include(x => x.User).Where(x => x.OrganizationID == userRecord.OrganizationID).FirstOrDefault();
            var organizationModuleRecord = dbContext.OrganizationModule.Include(x => x.Organization).Where(x => x.OrganizationID == organizationRecord.OrganizationID).FirstOrDefault();
            Assert.NotNull(organizationModuleRecord);
        }
    }
}
