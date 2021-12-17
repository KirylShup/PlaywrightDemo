using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightDemo.Pages
{
    public class UsersPage : BasePage
    {
        public override string URL => $"{Configuration.Configuration.Url}" + "/users";

        public override IPage Page { get; set; }
        public override IBrowser Browser { get; set; }
        public override IBrowserContext Context { get; set; }

        public UsersPage(IBrowser browser)
        {
            Browser = browser;
        }
        public UsersPage(IBrowserContext context)
        {
            Context = context;
        }
        public UsersPage(IPage page)
        {
            Page = page;
        }

        public Elements PageElements => new Elements();
        public sealed class Elements
        {
            public string InviteNewUserButtonOnPage => "//button[@id='Users-InviteButton']";
            public string FirstNameInputOnInviteDialog => "//input[@id='firstName']";
            public string LastNameInputOnInviteDialog => "//input[@id='lastName']";
            public string EmailInputOnInviteDialog => "//input[@id='email']";
            public string RolesDropdownOnInviteDialog => "//div[@id='role']/button";
            public string SpecificRoleInDropdownOnInviteDialog(string roleName) => $"//a[text()='{roleName}']";
            public string MessageInputOnInviteDialog => "//textarea[@id='message']";
            public string InviteNewUserButtonOnDialog => "//div[@class = 'modal-content']//button[text()= 'Invite New User']";
        }

        public async Task InviteNewUser(string firstName, string lastName, string email, string roleName = "Team Member", string message = null)
        {
            await Page.WaitForSelectorAsync(PageElements.InviteNewUserButtonOnPage);
            await Page.ClickAsync(PageElements.InviteNewUserButtonOnPage);
            await Page.FillAsync(PageElements.FirstNameInputOnInviteDialog, firstName);
            await Page.FillAsync(PageElements.LastNameInputOnInviteDialog, lastName);
            await Page.FillAsync(PageElements.EmailInputOnInviteDialog, email);
            await Page.ClickAsync(PageElements.RolesDropdownOnInviteDialog);
            await Page.ClickAsync(PageElements.SpecificRoleInDropdownOnInviteDialog(roleName));
            if (message != null)
            {
                await Page.FillAsync(PageElements.MessageInputOnInviteDialog, message);
            }
            await Page.ClickAsync(PageElements.InviteNewUserButtonOnDialog);
            // To select licenses for pre-assign we need data from DB
        }
    }
}
