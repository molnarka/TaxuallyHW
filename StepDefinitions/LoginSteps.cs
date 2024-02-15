namespace TaxuallyHW.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(IObjectContainer container)
        {
            var page = container.Resolve<IPage>();
            _loginPage = new LoginPage(page);
        }

        #region GIVEN

        [Given(@"Logged in with test user")]
        public async Task GivenLogdeInWithTestUser()
        {
            await _loginPage.NavigateToPage();
            await _loginPage.Login(TestDatas.GetTestUser());
        }

        #endregion
    }
}
