using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests;

public class PlayWrightTests : IAsyncLifetime, IDisposable
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync();
        _page = await _browser.NewPageAsync();
    }

    [Fact]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await _page.GotoAsync("https://playwright.dev");

        Assert.Contains("Playwright", await _page.TitleAsync());

        var getStarted = _page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        Assert.Equal("/docs/intro", await getStarted.GetAttributeAsync("href"));

        await getStarted.ClickAsync();

        Assert.Matches(new Regex(".*intro"), _page.Url);
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
