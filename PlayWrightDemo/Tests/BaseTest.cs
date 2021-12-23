using Microsoft.Playwright;
using NUnit.Framework;
using PlayWrightDemo.Core;
using System.Threading.Tasks;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPage page;
        protected string entitlementsConnectionString;

        [SetUp]
        public async Task Setup()
        {
            Configuration.Configuration.InitiateConfigurationFile();
            browser = await BrowserFactory.Instance();
            context = await browser.NewContextAsync(new BrowserNewContextOptions { ViewportSize = new ViewportSize { Width = 1980, Height = 1080 } });
            page = await context.NewPageAsync();
            entitlementsConnectionString = Configuration.Configuration.EntitlementsConnectionString;
        }

        [TearDown]
        public static async Task Teardown()
        {
            await BrowserFactory.QuitBrowser();
        }
    }
}
