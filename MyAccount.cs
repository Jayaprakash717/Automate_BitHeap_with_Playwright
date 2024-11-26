using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class MyAccountPage
    {
        private readonly IPage _page;

        public MyAccountPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToDashboardAsync()
        {
            await _page.ClickAsync("text=My Account");
            await _page.ClickAsync("text=Dashboard");
        }

        public async Task ViewOrdersAsync()
        {
            await _page.ClickAsync("text=Orders");
        }
    }
}
