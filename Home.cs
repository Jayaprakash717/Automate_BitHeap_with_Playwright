using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToLoginPageAsync()
        {
            await _page.GotoAsync("https://bitheap.tech");
        }

        public async Task NavigateToShopAsync()
        {
            await _page.ClickAsync("text=Shop");
        }

        public async Task NavigateToBlogAsync()
        {
            await _page.ClickAsync("text=Blog");
        }

        public async Task NavigateToContactUsAsync()
        {
            await _page.ClickAsync("text=Contact us");
        }
    }
}
