using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlayWrightDemo.Configuration;

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
            Browser engine = (Browser)Enum.Parse(typeof(Browser), Configuration.Configuration.Browser);
            if (browser == null)
            {
                switch (engine)
                {
                    case Browser.Chrome:
                        {
                            var playwright = await Playwright.CreateAsync();
                            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500 });
                            break;
                        }
                    case Browser.Safari:
                        {
                            var playwright = await Playwright.CreateAsync();
                            browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500 });
                            break;
                        }
                    case Browser.Firefox:
                        {
                            var playwright = await Playwright.CreateAsync();
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
