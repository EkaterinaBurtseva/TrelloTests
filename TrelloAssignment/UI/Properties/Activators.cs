using System;
namespace TrelloAssignment.UI.Properties
{
    public class Activators
    {

        public static T Get<T>() where T : IPage => BrowserContext.Instance.Browser.GetPage<T>();

    }
}
