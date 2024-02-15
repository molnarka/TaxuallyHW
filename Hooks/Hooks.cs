[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(1)]

namespace TaxuallyHW.Hooks
{
    [Binding]
    public class TestHooks
    {

        [BeforeScenario]
        public async Task BeforeScenarios(IObjectContainer container)
        {
            await InitPlaywright(container);
        }

        [AfterScenario]
        public async Task AfterScenarios(IObjectContainer container)
        {
            if (container != null)
            {
                await ClosePlaywright(container);
            }
        }

        private static async Task InitPlaywright(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions browserTypeLaunchOptions = new()
            {
                Channel = "chrome",
                SlowMo = 500,
                Headless = false,
            };
            var browser = await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);
            var context = await browser.NewContextAsync(new BrowserNewContextOptions()
            {
                ViewportSize = new ViewportSize() { Width = 1800, Height = 900 },
            });
            var page = await context.NewPageAsync();
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(context);
            container.RegisterInstanceAs(page);
        }

        private static async Task ClosePlaywright(IObjectContainer container)
        {
            var page = container.Resolve<IPage>();
            var context = container.Resolve<IBrowserContext>();
            var browser = container.Resolve<IBrowser>();
            var playwright = container.Resolve<IPlaywright>();

            await page.CloseAsync();
            await context.CloseAsync();
            await context.DisposeAsync();
            await browser.CloseAsync();
            await browser.DisposeAsync();
            playwright.Dispose();
            container.Dispose();
        }
    }
}

