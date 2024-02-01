When tests are run first time, they will fail. Test output will be following:

Microsoft.Playwright.PlaywrightException : Executable doesn't exist at C:\Users\lassi.autio\AppData\Local\ms-playwright\chromium-1076\chrome-win\chrome.exe
╔════════════════════════════════════════════════════════════╗
║ Looks like Playwright was just installed or updated.       ║
║ Please run the following command to download new browsers: ║
║                                                            ║
║     pwsh bin/Debug/netX/playwright.ps1 install             ║
║                                                            ║
║ <3 Playwright Team                                         ║
╚════════════════════════════════════════════════════════════╝


Run above command from this solution's root folder. It will take about 1 minute. After that tests will pass.