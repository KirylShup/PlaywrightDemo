using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlayWrightDemo.Utils;

namespace PlayWrightDemo.Core
{
    public class BrowserFactory
    {
        public enum Browser
        {
            Chrome,
            Safari,
            Firefox
        }

        private static IBrowser browser;
        public static async Task<IBrowser> Instance()
        {
            var playwright = await Playwright.CreateAsync();
            Browser engine = (Browser)Enum.Parse(typeof(Browser), Configuration.Configuration.Browser);
            if (browser == null)
            {
                switch (engine)
                {
                    case Browser.Chrome:
                        {
                            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500 });
                            break;
                        }
                    case Browser.Safari:
                        {
                            browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500 });
                            break;
                        }
                    case Browser.Firefox:
                        {
                            browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500 });
                            break;
                        }
                }

            }
            return browser;
        }

        public static async Task QuitBrowser(IPage page)
        {
            try 
            { 
                if (TestsHelper.IsTestFailed())
                {
                    await page.ScreenshotAsync(new PageScreenshotOptions 
                    { 
                        Type = ScreenshotType.Png,
                        Path = TestsHelper.CreateScreenshotFolder() + $"{TestContext.CurrentContext.Test.MethodName}_{RandomStringHelper.GetStringWithCurrentDate()}.png"
                    });
                }
            }
            finally 
            {
                await browser.CloseAsync();
                browser = null;
            }
        }
    }
}
