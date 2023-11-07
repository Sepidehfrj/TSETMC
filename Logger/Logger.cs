using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace TseTmc.Logger
{
   public class Logger: ILogger
    {
        private log4net.Core.ILogger _logger;
        /// <summary>
        /// get a new instance of the <see cref="Logger"/> class by name.
        /// You can add any appender by using LoggerCreator <see cref="LoggerCreator"/> class.
        /// If you not set any appender for a logger instance logger use root appender-ref with name DefaultAppender <see cref="log4net.config"/>
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        public Logger(string loggerName)
        {
            _logger = log4net.LogManager.GetLogger(loggerName).Logger;
        }
        public Logger(Type loggerType)
        {
            _logger = log4net.LogManager.GetLogger(typeof(Type)).Logger;
        }
        public void Debug(object message)
        {
            Debug(message, null);
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Log(typeof(Logger), Level.Debug, message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

        public void Error(object message)
        {
            Error(message, null);
        }

        public void Error(object message, Exception exception)
        {
            _logger.Log(typeof(Logger), Level.Error, message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public void Fatal(object message)
        {
            Fatal(message, null);
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Log(typeof(Logger), Level.Fatal, message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Fatal(string.Format(format, args));
        }

        public void Info(object message)
        {
            Info(message, null);
        }

        public void Info(object message, Exception exception)
        {
            _logger.Log(_logger.GetType(), Level.Info, message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        public void Warn(object message)
        {
            Warn(message, null);
        }

        public void Warn(object message, Exception exception)
        {

            _logger.Log(typeof(Logger), Level.Warn, message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }


    }
}
