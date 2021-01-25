using System;
using HtmlElements.Elements;
using HtmlElements.Extensions;
using OpenQA.Selenium;
using TrelloAssignment.UI.Base;
using TrelloAssignment.UI.Properties;
using Activator = TrelloAssignment.UI.Properties.Activators;

namespace TrelloAssignment.UI.Elements
{
    public static class ActionExtensions
    {
        private static IWebDriver driver => BrowserContext.Instance.Browser.Driver;


        public static T FindElementAs<T>(this IWebElement element, By by) where T : HtmlElement => element.FindElement(by).As<T>();

        public static TPage SelectOption_OpenPage<TPage>(this ElementsContainer optionsList, string optionPartialText) where TPage : IPage
        {
            IWebElement element = optionsList.WrappedElement.WaitForVisible().FindElementAs<HtmlElement>(By.XPath($"//li[contains(., '{optionPartialText}')]"));
            element.WaitForVisible().Click();
            return Activator.Get<TPage>();
        }
    }
}

