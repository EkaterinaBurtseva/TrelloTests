using System;
using NUnit.Framework.Internal;

namespace TrelloBasicApiTests.Properties
{
    public sealed class TestContext : IDisposable
    {
        private TestContext()
        {
        }

        private static TestContext instance = new TestContext();

        public static TestContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestContext();
                }
                return instance;
            }
        }

        public void Dispose()
        {
            instance = null;
        }

        public ILogger Logger { get; private set; }
        public bool CurrentTestResult { get; set; } = true;

        public ILogger SetLogger(ILogger logger)
        {
            Logger = logger;
            return Logger;
        }
    }
}
