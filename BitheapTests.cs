using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using PlaywrightProject.Pages;
using PlaywrightProject.Utilities;

namespace PlaywrightProject.Tests
{
    [TestFixture]
    public class BitHeapTests
    {
        private IBrowser _browser = null!;
        private IPage _page = null!;
        private CommonMethods _commonMethods = null!;


        [SetUp]
        public async Task Setup()
        {
            try
            {
                var playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

                if (_browser == null)
                    throw new Exception("Browser failed to initialize.");

                var context = await _browser.NewContextAsync();
                _page = await context.NewPageAsync();

                if (_page == null)
                    throw new Exception("Page failed to initialize.");

                _commonMethods = new CommonMethods(_page);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }


        [Test]
        public async Task TestLoginFunctionality()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.NavigateToLoginPageAsync();

            string username = Environment.GetEnvironmentVariable("USERNAME");
            string password = Environment.GetEnvironmentVariable("PASSWORD");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Environment variables USERNAME and PASSWORD are not set.");

            await loginPage.LoginAsync(username, password);
            var welcomeMessage = await loginPage.GetWelcomeMessageAsync();

            Assert.That(welcomeMessage, Is.Not.Null, "Welcome message is null.");
            Assert.That(welcomeMessage, Does.Contain("Welcome"), "Welcome message does not contain 'Welcome'.");
        }



        [Test]
        public async Task TestHomePageNavigation()
        {
            var homePage = new HomePage(_page);
            await homePage.NavigateToLoginPageAsync();
            await _commonMethods.TakeScreenshotAsync("Home_Page");
        }

        [Test]
        public async Task TestShopPageFunctionality()
        {
            var shopPage = new ShopPage(_page);
            await _commonMethods.LoginAsync();
            await shopPage.NavigateToShopAsync();
            await shopPage.AddToCartAsync("text=Add to Cart");
            await _commonMethods.TakeScreenshotAsync("Shop_Page");
        }

        [Test]
        public async Task TestBlogPageInteraction()
        {
            var blogPage = new BlogPage(_page);

            await _commonMethods.LoginAsync();
            await blogPage.NavigateToBlogAsync();
            await _page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
            await _commonMethods.TakeScreenshotAsync("Blog_Page");
        }

        [Test]
        public async Task TestContactUsForm()
        {
            var contactUsPage = new ContactUsPage(_page);
            await _commonMethods.LoginAsync();
            await contactUsPage.NavigateToContactUsAsync();
            await contactUsPage.FillContactFormAsync("John", "Doe", "john.doe@example.com", "Query", "This is a test message");
            await contactUsPage.SubmitFormAsync();
            await _commonMethods.TakeScreenshotAsync("ContactUs_Page");
        }

        [Test]
        public async Task TestMyAccountPage()
        {
            var myAccountPage = new MyAccountPage(_page);
            await _commonMethods.LoginAsync();
            await myAccountPage.NavigateToDashboardAsync();
            await _commonMethods.TakeScreenshotAsync("MyAccount_Dashboard");
            await myAccountPage.ViewOrdersAsync();
            await _commonMethods.TakeScreenshotAsync("MyAccount_Orders");
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }
        }

    }
}
