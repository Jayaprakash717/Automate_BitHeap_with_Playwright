using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToLoginPageAsync()
        {
            await _page.GotoAsync("https://bitheap.tech");
            await _page.ClickAsync("#menu-item-2330 > a");
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.Locator("[name='xoo-el-username']").FillAsync(username);
            await _page.Locator("[name='xoo-el-password']").FillAsync(password);
            await _page.Locator("//button[normalize-space()='Sign in']").ClickAsync();
        }

        public async Task<string> GetWelcomeMessageAsync()
        {
            var message = await _page.Locator("li[id='menu-item-2333'] a").TextContentAsync();
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "Screenshots/Login_Welcome.png" });
            return message;
        }
    }
}
