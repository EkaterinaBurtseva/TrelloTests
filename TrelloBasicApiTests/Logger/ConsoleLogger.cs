using System;
using Xunit.Abstractions;

namespace TrelloBasicApiTests.Logger
{
    public class ConsoleLogger : ILogger
    {
        private readonly ITestOutputHelper output;

        public ConsoleLogger(ITestOutputHelper output)
        {
            this.output = output;
        }

        public ILogger WriteLine(string logEntry)
        {
            output.WriteLine($"{timepstampFormatted} - {logEntry}");
            return this;
        }

        public ILogger BreakLine()
        {
            output.WriteLine(string.Empty);
            return this;
        }

        private string timepstampFormatted => DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
    }
}