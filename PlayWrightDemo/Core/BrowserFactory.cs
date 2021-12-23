using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

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

        public static async Task QuitBrowser()
        {
            await browser.CloseAsync();
            browser = null;
        }
    }
}
