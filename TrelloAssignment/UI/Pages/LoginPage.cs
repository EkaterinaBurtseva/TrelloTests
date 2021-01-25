using System;
using HtmlElements.Elements;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.UI.Base;

namespace TrelloAssignment.UI.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public LoginPage() : base()
        {
            Logger.Info("Login Page is opened");
        }

        public HtmlElement LoginForm => new HtmlElement(FindElement(By.Id("login-form")));
        public HtmlElement UserName => new HtmlElement(FindElement(By.Id("user")));
        public HtmlElement Password => new HtmlElement(FindElement(By.Id("password")));
        public HtmlElement LoginButton => new HtmlElement(FindElement(By.Id("login")));
        public HtmlElement LoginFormWithAtlassian => new HtmlElement(FindElement(By.ClassName("login-password-container")));
        public HtmlElement LoginButtonAtlassian => new HtmlElement(FindElement(By.Id("login-submit")));

        public bool IsLoginFormOpened()
        {
            Logger.Info("Check Login form appearance");
            return LoginForm.Displayed;
        }

        public bool IsLoginFormAttlasianOpened()
        {
            Logger.Info("Check Login with Atlasian form appearance");
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

        public LoginPage EnterPasswordAtlassian(string password)
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
