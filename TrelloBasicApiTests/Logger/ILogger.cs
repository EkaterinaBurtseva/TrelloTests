using System;
namespace TrelloBasicApiTests.Logger
{
    public interface ILogger
    {
        ILogger WriteLine(string logEntry);
        ILogger BreakLine();
    }
}
