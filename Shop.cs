using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightProject.Pages
{
    public class ShopPage
    {
        private readonly IPage _page;

        public ShopPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToShopAsync()
        {
            await _page.ClickAsync("text=Shop");
        }

        public async Task AddToCartAsync(string productSelector)
        {
            await _page.ClickAsync(productSelector);
        }

        public async Task ApplyCouponAsync(string couponCode)
        {
            await _page.FillAsync("#coupon_code", couponCode);
            await _page.ClickAsync("[name='apply_coupon']");
        }

        public async Task CheckoutAsync()
        {
            await _page.ClickAsync(".checkout-button");
        }
    }
}
