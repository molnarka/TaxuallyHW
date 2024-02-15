namespace TaxuallyHW.Pages
{
    public class LoginPage : BasePage
    {
        #region UI Elements

        private ILocator email => _page.Locator("#email");
        private ILocator password => _page.Locator("#password");
        private ILocator loginButton => _page.Locator("#next");

        #endregion

        public LoginPage(IPage page) : base(page)
        {
            PageURL = "https://app.taxually.com";
        }

        #region Methods

        public async Task Login(TestUser testUser)
        {
            await email.FillAsync(testUser.Email);
            await password.FillAsync(testUser.Password);
            await loginButton.ClickAsync();
        }

        #endregion
    }
}
