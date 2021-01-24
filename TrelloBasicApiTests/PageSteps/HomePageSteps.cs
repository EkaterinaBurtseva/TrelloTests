using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class HomePageSteps : BaseTestSteps
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
