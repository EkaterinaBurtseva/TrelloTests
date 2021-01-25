using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class TeamInfoPageSteps
    {
        public static TeamInfoPage OpenTeamInfoPage()
        {
            return Activators.Get<TeamInfoPage>();
        }
        TeamInfoPage teamInfoPage = OpenTeamInfoPage();
        public void VerifyTeamPageIsOpenedWithCorrectTeamName(string teamName)
        {
            Check.EqualBoolean(true, teamInfoPage.IsTeamInfoDisplayed(), "Team info displayed", "Team info isn't displayed");
            Check.EqualBoolean(true, teamInfoPage.GetTeamNameInfo().Contains(teamName));

        }

        public void CheckUsersForGivenEmail()
        {
            bool res = teamInfoPage.ClickMembersTab()
             .GetAllMembersName().Count > 0;

            Check.EqualBoolean(true, res, "Emails list isn't empty", "Emails list is empty");

        }
    }
}
