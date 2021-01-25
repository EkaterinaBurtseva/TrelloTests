using System;
using Allure.Commons;
using TechTalk.SpecFlow;
using TrelloAssignment.UI.Base;
using TrelloAssignment.UI.Steps;

namespace TrelloAssignment.StepBinding
{
    [Binding]
    public class UISteps : BaseSteps
    {
        private static readonly AllureLifecycle allure = AllureLifecycle.Instance;
        private MainLoggedPageSteps MainLoggedPageSteps;
        private BoardPageSteps BoardPageSteps;
        private LoginPageSteps LoginPageSteps;
        private HomePageSteps HomePageSteps;
        private CompanyInfoPageSteps CompanyInfoPageSteps;
        private TeamInfoPageSteps TeamInfoPageSteps;

        public UISteps(UiTestAssemblyFixture uiTestAssemblyFixture,
            UiTestClassFixture uiTestClassFixture, MainLoggedPageSteps mainLoggedPageSteps,
            BoardPageSteps boardPageSteps, LoginPageSteps loginPageSteps, HomePageSteps homePageSteps,
            CompanyInfoPageSteps companyInfoPageStep, TeamInfoPageSteps teamInfoPageSteps) :base(uiTestAssemblyFixture, uiTestClassFixture)
        {
            MainLoggedPageSteps = mainLoggedPageSteps;
            BoardPageSteps = boardPageSteps;
            LoginPageSteps = loginPageSteps;
            HomePageSteps = homePageSteps;
            CompanyInfoPageSteps = companyInfoPageStep;
            TeamInfoPageSteps = teamInfoPageSteps;

        }

       
        [StepDefinition(@"I login to the system as an existing user")]
        public void LoginToTheSystemAsExistingUser()
        {
            HomePageSteps.ClickLoginLinkFromHomePage();
            LoginPageSteps.LoginToTheSystemWithExistedUser();
            MainLoggedPageSteps.VerifyThatUserSuccessfullyLogged();

        }

        [StepDefinition(@"I create a dashboard (.*)")]
        public void CreateDashboard(string dashboardTitle)
        {
            MainLoggedPageSteps.CreateNewDashboard($"{dashboardTitle}{DateTime.Now.TimeOfDay}");

        }

        [StepDefinition(@"dashboard (.*) is existed in the list for the current user")]
        public void DashboardDisplayedInTheList(string dashboardTitle)
        {
            BoardPageSteps.VerifyBoardExistenseAndTitle(dashboardTitle);

        }

        [StepDefinition(@"I add card (.*) for '(.*)' list")]
        public void AddCardToList(string card, string list)
        {
            BoardPageSteps.AddCardToTheToDoList(list,card);
            BoardPageSteps.VerifyAddedCardDisplayedInTheList(card);
        }

        [StepDefinition(@"I delete dashboard (.*)")]
        public void IDeleteDashboard(string dashboardName)
        {
            BoardPageSteps.DeleteCurrentBoardFromTheSystem();
            MainLoggedPageSteps.VerifyThatDeletedDashboardIsntDisplayedInList(dashboardName);
        }

        [StepDefinition(@"I create a command (.*) with invalid email addresses (.*) for members")]
        public void ICommandWithInvalidEmails(string commandName, string emails)
        {
            MainLoggedPageSteps.StartCreateCommand();
            CompanyInfoPageSteps.FillInfoAboutCompanyAndTeam($"{commandName}{DateTime.Now.TimeOfDay}", $"{emails}{DateTime.Now.TimeOfDay}");

        }

        [StepDefinition(@"list of emails is displayed in members section for team (.*)")]
        public void ListEmailsInMembersSecrion(string teamName)
        { 
            TeamInfoPageSteps.VerifyTeamPageIsOpenedWithCorrectTeamName(teamName);
            TeamInfoPageSteps.CheckUsersForGivenEmail();

        }
    }
}

