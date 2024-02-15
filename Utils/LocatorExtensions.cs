namespace TaxuallyHW.Utils
{
    public static class LocatorExtensions
    {
        public static async Task ToBeVisibleAsync(this ILocator locator, int timeout = 30000) =>
            await Expect(locator).ToBeVisibleAsync(new() { Timeout = timeout });

        public static ILocator GetByExactText(this ILocator locator, string text)
        {
            return locator.GetByText(text, new LocatorGetByTextOptions() { Exact = true });
        }
    }
}
