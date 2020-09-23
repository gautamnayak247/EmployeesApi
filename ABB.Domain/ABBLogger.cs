using System;

namespace ABB.Domain
{
    public class ABBLogger : IABBLogger
    {
        public void LogError(string className, string methodName, string message, Exception ex) { }
        public void LogInformation(string className, string methodName, string message) { }
    }
}
