using Microsoft.Playwright;
using NUnit.Allure.Core;
using NUnit.Framework;
using PlayWrightDemo.Core;
using PlayWrightDemo.Pages;
using System.Threading.Tasks;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTestUi
    {
        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPage page;
        protected string entitlementsConnectionString;
        protected LoginPage loginPage;

        [SetUp]
        public async Task Setup()
        {
            Configuration.Configuration.InitiateConfigurationFile();
            entitlementsConnectionString = Configuration.Configuration.EntitlementsConnectionString;

            browser = await BrowserFactory.Instance();
            context = await browser.NewContextAsync(new BrowserNewContextOptions 
            { 
                ViewportSize = new ViewportSize { Width = 1980, Height = 1080 } 
            });
            page = await context.NewPageAsync();
            loginPage = new LoginPage(page);
        }

        [TearDown]
        public async Task Teardown()
        {
            await BrowserFactory.QuitBrowser(page);
        }
    }
}
