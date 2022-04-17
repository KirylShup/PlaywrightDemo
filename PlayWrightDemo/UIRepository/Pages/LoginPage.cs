using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlayWrightDemo.Pages
{
    public class LoginPage : BasePage
    {
        public override string URL => Configuration.Configuration.SelfServicePortalUrl;

        public override IPage Page { get; set; }
        public override IBrowser Browser { get; set; }
        public override IBrowserContext Context { get; set; }

        public LoginPage(IPage page)
        {
            Page = page;
        }

        public Elements PageElements => new Elements();
        public sealed class Elements
        {
            public string EmailInput => "//input[@name='email']";
            public string PasswordInput => "//input[@name='password']";
            public string LoginButton => "//span[text()='Log In']/parent::button";
        }

        public async Task<UsersPage> Login(string email, string password)
        {
            await Page.FillAsync(PageElements.EmailInput, email);
            await Page.FillAsync(PageElements.PasswordInput, password);
            await Page.ClickAsync(PageElements.LoginButton);
            await Page.WaitForLoadStateAsync();
            return new UsersPage(Page);
        }
    }
}
