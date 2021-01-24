using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class MainLoggedPageSteps: BaseTestSteps
    {
        private MainLoggedPage mainLoggedPage = new MainLoggedPage();
        public MainLoggedPageSteps( )
        {
        }

        public void CreateNewDashboard(String dashboardTitle)
        {
            mainLoggedPage.ClickAddNewDashboardTile()
                .WaitAndFillNewDashboardTitle(dashboardTitle)
                .ClickAddNewDashboardButton();
           
        }

        public void VerifyThatUserSuccessfullyLogged()
        {
            Check.EqualBoolean(true, mainLoggedPage.IsMainLoggedPageOpened(), "User is logged - main page is opened",
                "Main page isn't displayed");
        }

        public void VerifyThatDeletedDashboardIsntDisplayedInList(String dashboardTitle)
        {
            mainLoggedPage.ClickTrelloLogo();
            bool res = mainLoggedPage.GetAllBoards().FindAll(name => name.Contains(dashboardTitle)).ToArray().Length == 0;

            Check.EqualBoolean(true, res, $"dashboard with title {dashboardTitle} deleted from the system",
               $"dashboard with title {dashboardTitle} isn't deleted from the system");

        }

        public void StartCreateCommand()
        {
            mainLoggedPage.ClickAddNewItemBtnFromHeader()
                .ClickAddNewTeamOptionFromHeader();
        }
    }
}
