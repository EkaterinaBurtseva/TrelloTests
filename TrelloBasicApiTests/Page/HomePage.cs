using System;
using TrelloBasicApiTests.Helpers;

namespace TrelloBasicApiTests.Page
{
    public class HomePage : BasePage
    {
        private HomePage header => new HomePage(FindElement(By.Id("")

        public HomePage() : base()
        {
            LogName = "Home Page";
            Browser.GoTo(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);
            Browser.TakeScreenshot();
        }
    }
}

