using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Utilities
{
    public class CommonMethods
    {
        private readonly IPage _page;

        public CommonMethods(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync()
        {
            string username = Environment.GetEnvironmentVariable("USERNAME");
            string password = Environment.GetEnvironmentVariable("PASSWORD");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Environment variables USERNAME and PASSWORD are not set.");

            await _page.ClickAsync("text=Login");
            await _page.FillAsync("[name='xoo-el-username']", username);
            await _page.FillAsync("[name='xoo-el-password']", password);
            await _page.ClickAsync(".xoo-el-login-btn");
        }

        public async Task TakeScreenshotAsync(string fileName)
        {
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = $"Screenshots/{fileName}.png" });
        }
    }
}
