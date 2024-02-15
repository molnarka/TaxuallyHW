namespace TaxuallyHW.StepDefinitions
{
    [Binding]
    public class FinalizeSignUpSteps
    {
        private readonly FinalizeSignUpPage _finalizeSignUpPage;

        public FinalizeSignUpSteps(IObjectContainer container)
        {
            var page = container.Resolve<IPage>();
            _finalizeSignUpPage = new(page);
        }

        #region WHEN

        [When(@"Set Where is your business loacated to '(.*)'")]
        public async Task WhenSetWhereIsYourBusinessLocatedTo(string country)
        {
            await _finalizeSignUpPage.SetBusinessLocation(country);
        }

        [When(@"Select random primary countries '(.*)'")]
        public async Task WhenSelectRandomPrimaryCountries(int numOfCountries)
        {
            await _finalizeSignUpPage.SelectRandomPrimaryCountires(numOfCountries);
        }

        [When(@"Click all Get VAT number buttons")]
        public async Task WhenClickAllGetVATNumberButtons()
        {
            await _finalizeSignUpPage.ClickAllGetVATNumberButtons();
        }

        [When(@"Click Next step button on Sign up")]
        public async Task WhenClickNextStepButtonOnSignUp()
        {
            await _finalizeSignUpPage.ClickNextStepButton();
        }

        #endregion

        #region THEN

        [Then(@"Sign up page displayed")]
        public async Task ThenSignUpPageDisplayed()
        {
            await _finalizeSignUpPage.SignUpPageNeedsToBeDisplayed();
            await _finalizeSignUpPage.NavigateToPage(); //forece reload the page with the URL
            await _finalizeSignUpPage.SignUpPageNeedsToBeDisplayed();
        }

        #endregion
    }
}
