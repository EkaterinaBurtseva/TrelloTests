using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TrelloBasicApiTests.Helpers;

namespace TrelloBasicApiTests.Properties
{
    public class BrowserFactory
    {
        private readonly BrowserType browserType;

        public BrowserFactory(BrowserType? browserType = null)
        {
            this.browserType = browserType ?? RunGlobalSettingHelper.WebDriverSettings.GetSection("browser").Value.As<BrowserType>();
        }

        public Browser GetBrowser() => new Browser(GetDriver());

        private IWebDriver GetDriver()
        {
            IWebDriver driver;
            int commandTimeoutSeconds = Convert.ToInt32(RunGlobalSettingHelper.WebDriverSettings.GetSection("commandTimeout").Value);
            int searchTimeout = Convert.ToInt32(RunGlobalSettingHelper.WebDriverSettings.GetSection("searchTimeout").Value);
            int pageLoadTimeout = Convert.ToInt32(RunGlobalSettingHelper.WebDriverSettings.GetSection("pageLoadTimeout").Value);

            TestContext.Instance.Logger.WriteLine($"Starting {browserType}").BreakLine();

            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver(Environment.CurrentDirectory, GetChromeOptions(), TimeSpan.FromSeconds(commandTimeoutSeconds));
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(Environment.CurrentDirectory, GetFirefoxOptions(), TimeSpan.FromSeconds(commandTimeoutSeconds));
                    break;
                default:
                    throw new NotImplementedException("This browser is not supported yet");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(searchTimeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
            return driver;
        }

        
        private ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("intl.accept_languages", "en");
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddArgument("start-maximized");
            options.AddArgument("version");
            options.Proxy = null;
            return options;
        }

        private FirefoxOptions GetFirefoxOptions() => new FirefoxOptions();
       
    }
}
