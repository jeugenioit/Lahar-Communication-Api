using System;
using log4net;
using log4net.Config;
using JE.Common.LogService.Services.Interfaces;

namespace JE.Common.LogService.Services
{
    /// <summary>
    /// Class LogServices - Implements the ILogServices interface to log achievement in your application
    /// </summary>
    public class LogServices : ILogServices
    {
        #region Atributos
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        public void LogTrace(string message)
        {
           LogTrace(message, null);
        }

        public void LogTrace(string message, Exception ex)
        {
            XmlConfigurator.Configure();
            if (ex == null)
            {
                log.Info(string.Format("[LOGTRACE]: {0}", message));
            }
            else log.Info(string.Format("[LOGTRACE]: {0}", message), ex);
        }

        public void LogError(Exception ex)
        {
            LogError(ex, string.Empty);
        }

        public void LogError(Exception ex, string message)
        {
            XmlConfigurator.Configure();

            if (string.IsNullOrEmpty(message))
            {
                log.Error(string.Empty, ex);
            }
            else log.Error(message, ex);
        }


       
    }
}
