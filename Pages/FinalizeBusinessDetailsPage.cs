namespace TaxuallyHW.Pages
{
    public class FinalizeBusinessDetailsPage : BasePage
    {
        #region UI Elements

        private ILocator legalStatusSelect => _page.Locator("#companyLegalStatus");
        private ILocator companyLegalNameInput => _page.Locator("#companyLegalNameOfBusiness");
        private ILocator incorporationNumberInput => _page.Locator("#companyRegistrationNumber");
        private ILocator incorporationDatePickerButton => _page.Locator("[data-unique-id='registration-flow-company-info_button-toggle-datepicker']");
        private ILocator currentDateButton => _page.Locator("css=.ngb-dp-today");
        private ILocator companyAddressStateInput => _page.Locator("#companyState");
        private ILocator companyAddressZIPInput => _page.Locator("#companyZipCode");
        private ILocator companyAddressCityInput => _page.Locator("#companyCity");
        private ILocator companyAddressStreetInput => _page.Locator("#companyStreet");
        private ILocator companyAddressHouseNumberInput => _page.Locator("#companyHouseNumber");
        private ILocator nextStepButton => _page.Locator("[data-unique-id='registration-flow-company-info_button-next-step']");

        #endregion

        public FinalizeBusinessDetailsPage(IPage page) : base(page)
        {
            PageURL = "https://app.taxually.com/app/signup";
        }

        #region Methods

        public async Task BusinessDetailsPageNeedsToBeDisplayed()
        {
            await legalStatusSelect.ToBeVisibleAsync();
        }

        public async Task SetLegalStatus(string status)
        {
            await legalStatusSelect.FillAsync(status);
        }

        public async Task SetCompanyLegalName()
        {
            await companyLegalNameInput.ClearAsync();
            await companyLegalNameInput.FillAsync(
                $"{TestDatas.GetTestUser().FirstName} {TestDatas.GetTestUser().LastName} " +
                $"test company " +
                $"{DateTime.Now.ToString("yyyyMMdd")}");
        }

        public async Task SetRandomCompanyIncorporationNumber()
        {
            await incorporationNumberInput.ClearAsync();
            await incorporationNumberInput.FillAsync($"{new Random().Next(1, 100)}");
        }

        public async Task PickCurrentDate()
        {
            await incorporationDatePickerButton.ClickAsync();
            await currentDateButton.ClickAsync();
        }

        public async Task SetRandomCompanyAddressState()
        {
            await companyAddressStateInput.ClearAsync();
            await companyAddressStateInput.FillAsync($"{TestDatas.GetRandomString(5)}");
        }

        public async Task SetRandomCompanyAddressZIP()
        {
            await companyAddressZIPInput.ClearAsync();
            await companyAddressZIPInput.FillAsync($"{new Random().Next(1000, 9999)}");
        }

        public async Task SetRandomCompanyAddressCity()
        {
            await companyAddressCityInput.ClearAsync();
            await companyAddressCityInput.FillAsync($"{TestDatas.GetRandomString(5)}");
        }

        public async Task SetRandomCompanyAddressStreet()
        {
            await companyAddressStreetInput.ClearAsync();
            await companyAddressStreetInput.FillAsync($"{TestDatas.GetRandomString(5)}");
        }

        public async Task SetRandomCompanyAddressHouseNumber()
        {
            await companyAddressHouseNumberInput.ClearAsync();
            await companyAddressHouseNumberInput.FillAsync($"{new Random().Next(100, 999)}");
        }

        public async Task ClickNextStepButton()
        {
            await nextStepButton.ClickAsync();
        }
        #endregion
    }
}
