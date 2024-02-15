namespace TaxuallyHW.Pages
{
    public class FinalizeSignUpPage : BasePage
    {
        #region UI Elements

        private ILocator whereYourBusinessLocatedSelect => _page.Locator("[data-unique-id='registration-flow-subscription_select-country-establishment']");
        private ILocator countriesDropDownList => _page.Locator("[aria-label='Options list']");
        private ILocator primaryCountriesPanel => _page.Locator("xpath=//div[@class='accordionOpen']//div[@class='row'][1]");
        private ILocator primaryCountriesButtons => primaryCountriesPanel.Locator("css=button");
        private ILocator getVATNumberButtons => _page.Locator("css=button.add-vatreg-to-cart");
        private ILocator nextStepButton => _page.Locator("[data-unique-id='registration-flow-subscription_button-next-step']");

        #endregion

        public FinalizeSignUpPage(IPage page) : base(page)
        {
            PageURL = "https://app.taxually.com/app/signup";
        }

        #region Methods

        public async Task SignUpPageNeedsToBeDisplayed()
        {
            await whereYourBusinessLocatedSelect.ToBeVisibleAsync();
            await primaryCountriesPanel.ToBeVisibleAsync();
        }

        public async Task SetBusinessLocation(string country)
        {
            await whereYourBusinessLocatedSelect.ClickAsync();
            await countriesDropDownList.HoverAsync();
            await countriesDropDownList.GetByExactText(country).ScrollIntoViewIfNeededAsync();
            await countriesDropDownList.GetByExactText(country).ClickAsync();
        }

        public async Task SelectRandomPrimaryCountires(int numOfCountries)
        {
            Random rng = new();

            int numberOfDisplayedCountries = await primaryCountriesButtons.CountAsync();
            if (numOfCountries > numberOfDisplayedCountries)
            {
                Assert.Fail("There is not enough countries!");
            }

            List<int> randomCountryList = new();
            do
            {
                int randomNumber = rng.Next(0, numberOfDisplayedCountries - 1);
                if (!randomCountryList.Contains(randomNumber))
                {
                    randomCountryList.Add(randomNumber);
                }
            } while (randomCountryList.Count < numOfCountries);

            foreach (int i in randomCountryList)
            {
                await primaryCountriesButtons.Nth(i).ClickAsync();
            }
        }

        public async Task ClickAllGetVATNumberButtons()
        {
            do
            {
                await getVATNumberButtons.First.ClickAsync();
            } while (await getVATNumberButtons.CountAsync() > 0);
        }

        public async Task ClickNextStepButton()
        {
            await nextStepButton.ClickAsync();
        }

        #endregion
    }
}
