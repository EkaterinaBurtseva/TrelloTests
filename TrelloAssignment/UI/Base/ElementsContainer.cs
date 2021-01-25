using System;
using HtmlElements.Elements;
using OpenQA.Selenium;
using TrelloAssignment.UI.Elements;

namespace TrelloAssignment.UI.Base
{
    public class ElementsContainer : HtmlElement, IElementsContainer
    {
        protected readonly IWebElement wrappedElement;

        public ElementsContainer(IWebElement wrappedElement) : base(wrappedElement)
        {
            this.wrappedElement = wrappedElement;
        }

        protected T FindElementAs<T>(By by) where T : HtmlElement => wrappedElement.FindElement(by).As<T>();

        public string LogName { get; protected set; }  
    }
}
