# playwright_test
Playwright module provides a method to launch a browser instance. The following is a typical example of using Playwright to drive automation:
1. 先要安装dotnet tool
1. 把 dotnet tool 添加到环境环境变量
```
	cat << \EOF >> ~/.zprofile                    
	export PATH="$PATH:/Users/xxx/.dotnet/tools"
	EOF
```

1. Mac系统下还要安装powershell
1. 然后根据项目生成的脚本去安装浏览器
1. 
# Create project
dotnet new console -n PlaywrightDemo
cd PlaywrightDemo

# Add project dependency
dotnet add package Microsoft.Playwright
# Build the project
dotnet build
# Install required browsers
pwsh bin\Debug\netX\playwright.ps1 install

# Code
```
using Microsoft.Playwright;
using System.Threading.Tasks;

class PlaywrightExample
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://www.microsoft.com");
        // other actions...
    }
}
```
