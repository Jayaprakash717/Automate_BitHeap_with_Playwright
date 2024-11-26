using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class BlogPage
    {
        private readonly IPage _page;

        public BlogPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToBlogAsync()
        {
            await _page.ClickAsync("text=Blog");
        }

        public async Task LikeBlogPostAsync(string postTitle)
        {
            await _page.ClickAsync($"text={postTitle}");
            await _page.ClickAsync("text=Like");
        }
    }
}
