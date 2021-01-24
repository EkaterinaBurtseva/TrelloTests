using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class LoginPageSteps: BaseTestSteps
    {

        private LoginPage loginPage = new LoginPage();

        public void LoginToTheSystemWithExistedUser()
        {
            Check.EqualBoolean(true, loginPage.IsLoginFormOpened(), "Login form is opened", "Login form isn't displayed");
            loginPage.EnterUsername("hubba2647bubba@gmail.com");
            if (loginPage.IsLoginFormAttlasianOpened())
            {
                loginPage.ClickLoginButton()
                    .EnterPassword("Testing123@")
                    .ClickLoginAttlasianButton();
            }
            else
            {
                loginPage.EnterPassword("Testing123@")
                    .ClickLoginButton();
            }

        }
    }
}
