using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var playwright = await Playwright.CreateAsync();
            var broOptions = new BrowserTypeLaunchOptions();

            var browser = await playwright.Chromium.LaunchAsync(broOptions);
            var context = await browser.NewContextAsync(playwright.Devices["iPhone x"]);

            var page = context.NewPageAsync().Result;
            await page.GotoAsync("https://www.baidu.com");
            //Thread.Sleep(1000);
            PageScreenshotOptions options2 = new PageScreenshotOptions();
            options2.Path = "screenshot.png";
            options2.FullPage = true;
            var fileBytes = await page.ScreenshotAsync(options2);

            MemoryStream imageStream = new MemoryStream();
            imageStream.Write(fileBytes, 0, fileBytes.Length);
            FileStream fs = File.Create("/Users/jeffrey/Documents/Github/PlaywrightTest/PlaywrightT/screenshot.png");
            imageStream.WriteTo(fs);

            fs.Close();
            imageStream.Close();
            Console.WriteLine("save");

        }

    }
}
