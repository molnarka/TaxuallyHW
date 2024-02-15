namespace TaxuallyHW.StepDefinitions
{
    [Binding]
    public class FinalizeBusinessDetailsSteps
    {
        private readonly FinalizeBusinessDetailsPage _finalizeBusinessDetailsPage;

        public FinalizeBusinessDetailsSteps(IObjectContainer container)
        {
            var page = container.Resolve<IPage>();
            _finalizeBusinessDetailsPage = new(page);
        }

        #region WHEN

        [When(@"Set Legal status to '(.*)'")]
        public async Task WhenSetLegalStatusTo(string status)
        {
            await _finalizeBusinessDetailsPage.SetLegalStatus(status);
        }

        [When(@"Set Full legal name")]
        public async Task WhenSetFullLegalName()
        {
            await _finalizeBusinessDetailsPage.SetCompanyLegalName();
        }

        [When(@"Set random Incorporation number")]
        public async Task WhenSetRandomIncorporationNumber()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyIncorporationNumber();
        }

        [When(@"Pick current date")]
        public async Task WhenPickCurrentDate()
        {
            await _finalizeBusinessDetailsPage.PickCurrentDate();
        }

        [When(@"Set random State")]
        public async Task WhenSetRandomState()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyAddressState();
        }

        [When(@"Set random ZIP")]
        public async Task WhenSetRandomZIP()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyAddressZIP();
        }

        [When(@"Set random City")]
        public async Task WhenSetRandomCity()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyAddressCity();
        }

        [When(@"Set random Street")]
        public async Task WhenSetRandomStreet()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyAddressStreet();
        }

        [When(@"Set random House number")]
        public async Task WhenSetRandomHouseNumber()
        {
            await _finalizeBusinessDetailsPage.SetRandomCompanyAddressHouseNumber();
        }

        [When(@"Click Next step button on Business details")]
        public async Task WhenClickNextStepButtonOnSignUp()
        {
            await _finalizeBusinessDetailsPage.ClickNextStepButton();
        }

        #endregion

        #region THEN

        [Then(@"Business details page displayed")]
        public async Task ThenBusinessDetailsPageDisplayed()
        {
            await _finalizeBusinessDetailsPage.BusinessDetailsPageNeedsToBeDisplayed();
        }

        [Then(@"Wait 5 seconds to see the result")]
        public async Task ThenWait5Seconds()
        {
            await _finalizeBusinessDetailsPage.BusinessDetailsPageNeedsToBeDisplayed();
        }

        #endregion
    }
}
