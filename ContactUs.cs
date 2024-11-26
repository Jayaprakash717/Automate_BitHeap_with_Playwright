using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class ContactUsPage
    {
        private readonly IPage _page;

        public ContactUsPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToContactUsAsync()
        {
            await _page.ClickAsync("text=Contact us");
        }

        public async Task FillContactFormAsync(string firstName, string lastName, string email, string subject, string message)
        {
            await _page.FillAsync("#fieldFirstName", firstName);
            await _page.FillAsync("#fieldLastName", lastName);
            await _page.FillAsync("#fieldEmail", email);
            await _page.FillAsync("#fieldSubject", subject);
            await _page.FillAsync("#fieldMessage", message);
        }

        public async Task SubmitFormAsync()
        {
            await _page.ClickAsync("text=Submit");
        }
    }
}
