using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JE.Common.LogService.Services.Interfaces
{
    /// <summary>
    /// Interface ILogServices - Exhibiting method for conducting logging in application
    /// </summary>
    public interface ILogServices
    {
        /// <summary>
        /// Write logs you mapped out for display as trace
        /// </summary>
        /// <param name="message"></param>
        void LogTrace(string message);

        /// <summary>
        /// Write logs you mapped out for display as trace
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        void LogTrace(string message, Exception ex);

        /// <summary>
        /// Write error logs treated by you in your application
        /// </summary>
        /// <param name="ex"></param>
        void LogError(Exception ex);

        /// <summary>
        /// Write error logs treated by you in your application
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        void LogError(Exception ex, string message);
    }
}
