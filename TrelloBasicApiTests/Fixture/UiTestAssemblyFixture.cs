using System;
using Xunit;

namespace TrelloBasicApiTests.Fixture
{
    public class UiTestAssemblyFixture : IDisposable
    {
        public UiTestAssemblyFixture()
        {
        }
        public void Dispose()
        { }

        public class UiTestAssemblyCollection : ICollectionFixture<UiTestAssemblyFixture> { }

    }
}
