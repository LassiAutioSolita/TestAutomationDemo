using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests;

/// <summary>
/// This class is based on the Playwright example at https://playwright.dev/dotnet/docs/intro
/// but for xUnit test framework.
/// </summary>
public class PlayWrightTests : IAsyncLifetime, IDisposable
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        _page = await _browser.NewPageAsync();
    }

    // Focus on this method, it is the test.
    [Fact]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await _page.GotoAsync("https://playwright.dev");

        // Check that the title contains "Playwright".
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Assert.Contains("Playwright", await _page.TitleAsync());

        // Find the "Get started" link (or button).
        var getStarted = _page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Check that the link points to the intro page.
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Assert.Equal("/docs/intro", await getStarted.GetAttributeAsync("href"));

        // Click the link.
        await getStarted.ClickAsync();

        // Check that the URL contains "intro".
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Assert.Contains("intro", _page.Url);
    }

    public async Task DisposeAsync()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
    }

    public void Dispose()
    {
        _playwright.Dispose();
    }
}
