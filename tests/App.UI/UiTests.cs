using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace App.UI;

public class UiTests
{
    [Fact]
    public async Task Sum_Shows_Result_In_Page()
    {
        using var playwright = await Playwright.CreateAsync();

        var browserName = Environment.GetEnvironmentVariable("BROWSER") ?? "chromium";
        IBrowserType browserType = browserName switch
        {
            "firefox" => playwright.Firefox,
            "webkit" => playwright.Webkit,
            _ => playwright.Chromium
        };

        await using var browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("http://localhost:5187/");
        await page.FillAsync("#a", "2");
        await page.FillAsync("#b", "3");
        await page.ClickAsync("#sumButton");
        await page.WaitForSelectorAsync("#result");
        var text = await page.InnerTextAsync("#result");
        Assert.Contains("5", text);
    }
}

