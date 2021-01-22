using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TrelloBasicApiTests.Page
{
    public class LoginPage: BasePage
    {
        public LoginPage():base()
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

        public bool IsLoginFormOpened()
        {
            return LoginForm.Displayed;
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void EnterPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void EnterUsername(string username)
        {
            UserName.SendKeys(username);
        }


    }
}
