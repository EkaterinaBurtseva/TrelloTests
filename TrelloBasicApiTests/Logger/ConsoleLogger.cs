using System;
using Xunit.Abstractions;

namespace TrelloBasicApiTests.Logger
{
    public class ConsoleLogger
    {
        private readonly ITestOutputHelper output;

        public ConsoleLogger(ITestOutputHelper output)
        {
            this.output = output;
        }

        public ILogger WriteLine(string log)
        {
            output.WriteLine($"{timepstampFormatted} - {log}");
            return (ILogger)this;
        }

        public ILogger BreakLine()
        {
            output.WriteLine(string.Empty);
            return (ILogger)this;
        }

        private string timepstampFormatted => DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
    }
}
