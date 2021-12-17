using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PlayWrightDemo.Database;
using PlayWrightDemo.Pages;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public async Task SampleOfUITest()
        {
            var loginPage = new LoginPage(page);
            await loginPage.NavigateByURL();
            var usersPage = loginPage.Login("kiryl_user_75950929@mail.com", "CConnect123").Result;
            await usersPage.InviteNewUser("Kiryl", "Shupenich", "ks_playwright_test4@mailinator.com");
            using var dbContext = new EntitlementsContext(entitlementsConnectionString);
            var userRecord = dbContext.User.Include(u => u.InvitationToJoin).Where(x => x.EmailAddress == "kiryl_user_75950929@mail.com").FirstOrDefault();
        }

        [Test]
        public async Task SampleOfAPITest()
        {
            var client = new RestClient("some URL here");
            var request = new RestRequest(Method.GET);


        }
    }
}
