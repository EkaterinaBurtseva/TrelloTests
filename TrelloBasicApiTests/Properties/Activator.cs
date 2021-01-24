using System;
using TrelloBasicApiTests.Page;

namespace TrelloBasicApiTests.Properties
{
    public class Activator
    {
        public static T Get<T>() where T : IPage => BrowserContext.Instance.Browser.GetPage<T>();
    }
}
