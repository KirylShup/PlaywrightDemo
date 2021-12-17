using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayWrightDemo.Pages
{
    public abstract class BasePage
    {
        public abstract string URL { get; }

        public abstract IPage Page { get; set; }
        public abstract IBrowser Browser { get; set; }
        public abstract IBrowserContext Context { get; set; }
        public async Task NavigateByURL()
        {
            await Page.GotoAsync(URL);
        }
    }
}