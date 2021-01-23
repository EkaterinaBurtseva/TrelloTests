using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;

namespace TrelloBasicApiTests.PageSteps
{
    public class HomePageSteps
    {
        private HomePage homePage = new HomePage();
        public HomePageSteps()
        {
        }

        public void ClickLoginLinkFromHomePage()
        {
            Check.EqualBoolean(true, homePage.IsHomePageOpened(), "Home page is opened", "Home page isn't displayed");
            homePage.ClickLoginLink();
        }
    }
}
