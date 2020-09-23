using System;

namespace ABB.Domain
{
    public interface IABBLogger
    {
        void LogInformation(string className, string methodName, string message);
        void LogError(string className, string methodName, string message, Exception ex);
    }
}