using System;
using HtmlElements.Elements;
using OpenQA.Selenium;

namespace TrelloAssignment.UI.Elements
{
    public static class CastExtensions
    {
        public static T As<T>(this IWebElement element) where T : HtmlElement => (T)Activator.CreateInstance(typeof(T), new object[] { element });
    }
}

