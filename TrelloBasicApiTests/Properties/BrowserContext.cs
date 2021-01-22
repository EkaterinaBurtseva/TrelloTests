using System;
namespace TrelloBasicApiTests.Properties
{
    public sealed class BrowserContext: IDisposable
    {
        private BrowserContext()
        {
            Browser = new BrowserFactory().GetBrowser();
        }

        private static BrowserContext instance = new BrowserContext();

        public static BrowserContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrowserContext();
                }
                return instance;
            }
        }

        public void Dispose()
        {
            instance?.Browser?.Dispose();
            instance = null;
        }

        public Browser Browser { get; private set; }
    }
}
