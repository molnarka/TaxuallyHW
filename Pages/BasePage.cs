namespace TaxuallyHW.Pages
{
    public class BasePage
    {
        public string PageURL = string.Empty;
        protected IPage _page;

        public BasePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToPage()
        {
            await _page.GotoAsync(PageURL);
        }

        public string GetActualPageURL()
        {
            return _page.Url;
        }

        public async Task Wait5Seconds()
        {
            await _page.WaitForTimeoutAsync(5000);
        }
    }
}
