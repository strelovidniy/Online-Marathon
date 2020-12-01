using System;

namespace Sprint_10.Task_10
{
    public class ExceptionLogger
    {
        private ILogger _logger;
        
        public void LogException(Exception mException)
            => _logger.LogMessage(GetUserReadableMessage(mException));

        public void LogIntoFile(Exception mException)
        {
            var objFileLogger = new FileLogger();
            objFileLogger.LogMessage(GetUserReadableMessage(mException));
        }

        public void LogIntoDataBase(Exception mException)
        {
            var objDbLogger = new DbLogger();
            objDbLogger.LogMessage(GetUserReadableMessage(mException));
        }

        private string GetUserReadableMessage(Exception ex)
        {
            var strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user   
            // readable format.  
            return strMessage;
        }

        public ExceptionLogger(ILogger logger)
            => _logger = logger;

        public ExceptionLogger()
        {
            
        }
    }
}
