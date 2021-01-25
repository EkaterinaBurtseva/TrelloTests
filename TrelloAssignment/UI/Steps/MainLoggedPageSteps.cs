using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class MainLoggedPageSteps
    {
        public static MainLoggedPage OpenMainLoggedPage()
        {
            return Activators.Get<MainLoggedPage>();
        }

        MainLoggedPage mainLoggedPage = OpenMainLoggedPage();
        public void CreateNewDashboard(string dashboardTitle)
        {
            mainLoggedPage.ClickAddNewDashboardTile()
                .WaitAndFillNewDashboardTitle(dashboardTitle)
                .ClickAddNewDashboardButton();

        }

        public void VerifyThatUserSuccessfullyLogged()
        {
            mainLoggedPage.WaitTillLoaded();
            Check.EqualBoolean(true, mainLoggedPage.IsMainLoggedPageOpened(), "User is logged - main page is opened",
                "Main page isn't displayed");
        }

        public void VerifyThatDeletedDashboardIsntDisplayedInList(string dashboardTitle)
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
