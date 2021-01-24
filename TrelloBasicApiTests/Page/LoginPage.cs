using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloBasicApiTests.Properties;

namespace TrelloBasicApiTests.Page
{
    public class LoginPage : BasePage
    {
        public LoginPage() : base()
        {
            LogName = "Login Page";
        }

        [FindsBy(How = How.Id, Using = "login-form")]
        private IWebElement LoginForm;

        [FindsBy(How = How.Id, Using = "user")]
        private IWebElement UserName;

        [FindsBy(How = How.Id, Using = "password-entry")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement LoginButton;

        [FindsBy(How = How.Id, Using = "login-password-container")]
        private IWebElement LoginFormWithAtlassian;

        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement LoginButtonAtlassian;


        public bool IsLoginFormOpened()
        {
            TestContext.Instance.Logger.BreakLine().WriteLine("Check Login form appearance");
            return LoginForm.Displayed;
        }

        public bool IsLoginFormAttlasianOpened()
        {
            TestContext.Instance.Logger.BreakLine().WriteLine("Check Login with Atlasian form appearance");
            return LoginFormWithAtlassian.Displayed;
        }

        public LoginPage ClickLoginButton()
        {

            LoginButton.Click();
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            Password.SendKeys(password);
            return this;
        }

        public LoginPage EnterUsername(string username)
        {
            UserName.SendKeys(username);
            return this;
        }

        public LoginPage ClickLoginAttlasianButton()
        {
            LoginButtonAtlassian.Click();
            return this;
        }


    }
}
