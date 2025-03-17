using NLog;

namespace TechnicalTask.Utilities
{
    public static class Logger
    {
        // Create a logger instance for the current class
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        // Log an informational message
        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        // Log an error message
        public static void LogError(string message)
        {
            logger.Error(message);
        }
    }
}
