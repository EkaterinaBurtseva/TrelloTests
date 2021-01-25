using System;
using System.IO;
using HtmlElements;
using HtmlElements.Extensions;
using OpenQA.Selenium;

namespace TrelloAssignment.UI.Properties
{
    public class Browser : IDisposable
    {
        private IPage currentPage;

        public Browser(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        public IWebDriver Driver { get; private set; }

        public void Initialize<T>() where T : IPage
        {
            IPageObjectFactory pageObjectFactory = new PageObjectFactory();
            currentPage = pageObjectFactory.Create<T>(Driver);
        }

        public T GetPage<T>() where T : IPage
        {
            if (currentPage == null || currentPage.GetType() != typeof(T))
            {
                Initialize<T>();
            }
            return GetCurrentPage<T>();
        }

        public T GetCurrentPage<T>() => (T)currentPage;

        public void Dispose()
        {
            try
            {
                Driver.Quit();
                Driver.Dispose();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        public void GoTo(string url) => Driver.Navigate().GoToUrl(url);

        public string TakeScreenshot()
        {
            string location = Path.Combine(Environment.CurrentDirectory, "Screenshots");
            Directory.CreateDirectory(location);
            string fullFileName = Path.Combine(location, DateTime.Now.ToString("WebDriver_Screen_yyyy-MM-dd_HH-mm-ss") + ".png");
            ((ITakesScreenshot)Driver).SavePageImage(fullFileName, ScreenshotImageFormat.Png);
            return fullFileName;
        }
    }
}
