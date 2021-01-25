using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class LoginPageSteps
    {
        public static LoginPage OpenLoginPage()
        {
            return Activators.Get<LoginPage>();
        }

        public void LoginToTheSystemWithExistedUser()
        {
            LoginPage loginPage = OpenLoginPage();
            Check.EqualBoolean(true, loginPage.IsLoginFormOpened(), "Login form is opened", "Login form isn't displayed");
            loginPage.EnterUsername("hubba2647bubba@gmail.com");
            if (loginPage.IsLoginFormAttlasianOpened())
            {
                loginPage.ClickLoginButton()
                    .EnterPasswordAtlassian("Testing123@")
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
