using System;
using Allure.Commons;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TrelloBasicApiTests.Page;
using TrelloBasicApiTests.PageSteps;

namespace TrelloTests.Steps
{
    [Binding]
    public class UISteps : BaseTestSteps
    {
      
        private MainLoggedPageSteps mainLoggedPageSteps = new MainLoggedPageSteps();
        private BoardPageSteps boardPageSteps = new BoardPageSteps();
        private LoginPageSteps loginPageSteps = new LoginPageSteps();
        private HomePageSteps homePageSteps = new HomePageSteps();
        private CompanyInfoPageSteps companyInfoPageSteps = new CompanyInfoPageSteps();
        private TeamInfoPageSteps teamInfoPageSteps = new TeamInfoPageSteps();
        public UISteps()
        {

        }

        [StepDefinition(@"I login to the system as an existing user")]
        public void LoginToTheSystemAsExistingUser()
        {
            homePageSteps.ClickLoginLinkFromHomePage();
            loginPageSteps.LoginToTheSystemWithExistedUser();
            mainLoggedPageSteps.VerifyThatUserSuccessfullyLogged();

        }

        [StepDefinition(@"I create a dashboard (.*)")]
        public void CreateDashboard(String dashboardTitle)
        {
            mainLoggedPageSteps.CreateNewDashboard(dashboardTitle);

        }

        [StepDefinition(@"dashboard (.*) is existed in the list for the current user")]
        public void DashboardDisplayedInTheList(String dashboardTitle)
        {
            boardPageSteps.VerifyBoardExistenseAndTitle(dashboardTitle);

        }

        [StepDefinition(@"I add card (.*) for 'TODO' list")]
        public void AddCardToList(String card)
        {
            boardPageSteps.AddCardToTheToDoList(card);
            boardPageSteps.VerifyAddedCardDisplayedInTheList(card);
        }

        [StepDefinition(@"I delete dashboard (.*)")]
        public void IDeleteDashboard(String dashboardName)
        {
            boardPageSteps.DeleteCurrentBoardFromTheSystem();
            mainLoggedPageSteps.VerifyThatDeletedDashboardIsntDisplayedInList(dashboardName);
        }

        [StepDefinition(@"I create a command (.*) with invalid email addresses (.*) for members")]
        public void ICommandWithInvalidEmails(String commandName, String emails)
        {
            mainLoggedPageSteps.StartCreateCommand();
            companyInfoPageSteps.FillInfoAboutCompanyAndTeam(commandName, emails);

        }

        [StepDefinition(@"list of emails is displayed in members section for team (.*)")]
        public void ListEmailsInMembersSecrion(String teamName)
        {
            teamInfoPageSteps.VerifyTeamPageIsOpenedWithCorrectTeamName(teamName);
            teamInfoPageSteps.CheckUsersForGivenEmail()

        }
    }
}
