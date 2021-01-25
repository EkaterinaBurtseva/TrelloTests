using System;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Base
{
    public abstract class BaseSteps : IDisposable
    {
        protected UiTestAssemblyFixture UiTestAssemblyFixture;
        protected UiTestClassFixture UiTestClassFixture;


        public BaseSteps(UiTestAssemblyFixture uiTestAssemblyFixture, UiTestClassFixture uiTestClassFixture)
        {
            UiTestAssemblyFixture = uiTestAssemblyFixture;
            UiTestClassFixture = uiTestClassFixture;

        }

        public void Dispose()
        {

            BrowserContext.Instance.Dispose();

        }

    }
}
