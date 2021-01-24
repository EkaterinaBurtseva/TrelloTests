using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class TeamInfoPageSteps : BaseTestSteps
    {
        private TeamInfoPage teamInfoPage = new TeamInfoPage();
        public TeamInfoPageSteps()
        {
        }

        public void VerifyTeamPageIsOpenedWithCorrectTeamName(String teamName)
        {
            Check.EqualBoolean(true, teamInfoPage.IsTeamInfoDisplayed(), "Team info displayed", "Team info isn't displayed");
            Check.Equal(teamName, teamInfoPage.GetTeamNameInfo());

        }

        public void CheckUsersForGivenEmail()
        {
            bool res = teamInfoPage.ClickMembersTab()
             .GetAllMembersName().Count > 0;

            Check.EqualBoolean(true, res, "Emails list isn't empty", "Emails list is empty");

        }
    }
}
