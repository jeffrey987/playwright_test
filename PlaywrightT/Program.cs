using System;
using System.Collections.Generic;
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
            broOptions.Devtools = true;
            var browser = await playwright.Chromium.LaunchAsync(broOptions);

            var context = await browser.NewContextAsync(playwright.Devices["iPhone x"]);
            float expires = DateTime.Now.AddDays(2).Millisecond / 1000;

            var cookieList = new List<Cookie>(); //GA1.2.381984011.1644804858

            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "V2EX_TAB", Value = "2|1:0|10:1644905735|8:V2EX_TAB|8:dGVjaA==|6aabadafb8d552c95ec2056f193f9217a00d14d61a2b32c5eab8c6588c1684a2", Expires = expires });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "PB3_SESSION", Value = "2|1:0|10:1644905639|11:PB3_SESSION|40:djJleDoyMDIuMTgyLjEyNi4yNTM6MTk1MjExMzM=|f2c4f103c0d67f15dac75d5d9db3aaf5d3cad3d41f02c01c8f26641f7a881342", Expires = expires });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "V2EX_LANG", Value = "zhcn", Expires = DateTime.Now.AddDays(1).Millisecond });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "_gid", Value = "GA1.2.167558986.1644905639", Expires = DateTime.Now.AddDays(1).Millisecond });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "__gads", Value = "ID=e7e2edfb0e63b067-221dabe8a0d00069:T=1644905639:RT=1644905639:S=ALNI_MZtzviqbLVS-d8Wy9yWIuZwNfFOlg", Expires = expires });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "_ga", Value = "GA1.2.750998002.1644905639", Expires = DateTime.Now.AddDays(1).Millisecond });
            cookieList.Add(new Cookie { Path = "/", Domain = ".v2ex.com", Name = "A2", Value = "2 | 1:0 | 10:1644905734 | 2:A2 | 56:OTU5NzAzYThlNDdkOTNmOWNjMDM3N2U1OTk1YzIzMGJhNjI4YjlhZg ==| 893d75d2e66bc89907f54e23b25fa2a0f09526ae0f170ac6ed14dc3c5aac51d5", Expires = expires });
            cookieList.Add(new Cookie { Path = "/", Domain = "*",Name="test",Value="test" });
            var page = context.NewPageAsync().Result;
            
            await page.GotoAsync("https://www.v2ex.com/mission/daily/redeem?once=2415");
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
