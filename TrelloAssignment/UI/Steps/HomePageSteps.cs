using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class HomePageSteps
    {

        public static HomePage OpenHomePage()
        {
            return Activators.Get<HomePage>();
        }

        public void ClickLoginLinkFromHomePage()
        {
            HomePage homePage = OpenHomePage();
            Check.EqualBoolean(true, homePage.IsHomePageOpened());
            homePage.ClickLoginLink();
        }
    }
}
