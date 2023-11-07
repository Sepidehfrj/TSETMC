using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Layout;

namespace TseTmc.Logger
{
  public static  class LoggerCreator
    {

        /// <summary>
        /// Creates the file appender for a nemed logger
        /// </summary>
        /// <param name="appenderName">The appender name for logger.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>IAppender.</returns>
        public static IAppender CreateFileAppender(string appenderName, string fileName)
        {
            FileAppender appender = new FileAppender();
            appender.Name = appenderName;
            appender.File = fileName;
            appender.AppendToFile = true;
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n";
            layout.ActivateOptions();
            appender.Layout = layout;
            appender.ActivateOptions();
            return appender;
        }


        public static void AddAppender(string loggerName, IAppender appender)
        {
            ILog log = LogManager.GetLogger(loggerName);
            log4net.Repository.Hierarchy.Logger l = (log4net.Repository.Hierarchy.Logger)log.Logger;
            l.AddAppender(appender);
        }

        // Find a named appender already attached to a logger
        public static IAppender FindAppender(string appenderName)
        {
            foreach (IAppender appender in LogManager.GetRepository().GetAppenders())
            {
                if (appender.Name == appenderName)
                {
                    return appender;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets the logger level.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="levelName">Name of the level.</param>
        public static void SetLevel(string loggerName, string levelName)
        {
            ILog log = LogManager.GetLogger(loggerName);
            log4net.Repository.Hierarchy.Logger l =
                (log4net.Repository.Hierarchy.Logger)log.Logger;
            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        /// <summary>
        /// Creates the console appender.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns>IAppender.</returns>
        public static IAppender CreateConsoleAppender(string loggerName)
        {
            ConsoleAppender appender = new ConsoleAppender();
            appender.Name = loggerName;
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "% newline % date % -5level % logger – % message – % property % newline";
            layout.ActivateOptions();
            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }

        /// <summary>
        /// Creates the ADO net appender.
        /// </summary>
        /// <param name="cs">The ConnectionString For ADO Logger.</param>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns>IAppender.</returns>
        public static IAppender CreateAdoNetAppender(string cs, string loggerName)
        {
            AdoNetAppender appender = new AdoNetAppender();
            appender.Name = "AdoNetAppender";
            appender.BufferSize = 1;
            appender.ConnectionType = "System.Data.SqlClient.SqlConnection, System.Data, Version = 1.0.3300.0, Culture = neutral, PublicKeyToken = b77a5c561934e089";
            appender.ConnectionString = cs;
            appender.CommandText = @"INSERT INTO AppLog
                ([DateUtc],[Thread],[Level],[Logger],[User],[Message],[Exception]) VALUES
                (@date, @appcode, @thread, @level, @logger, @user, @message, @exception)";

            AddDateTimeParameterToAppender(appender, "date");
            AddStringParameterToAppender(appender, "thread", 20, "%thread");
            AddStringParameterToAppender(appender, "level", 10, "%level");
            AddStringParameterToAppender(appender, "logger", 200, "%logger");
            AddStringParameterToAppender(appender, "user", 20, "%property{ user}");
            AddStringParameterToAppender(appender, "message", 1000, "%message%newline%property");
            AddErrorParameterToAppender(appender, "exception", 4000);
            appender.ActivateOptions();
            return appender;
        }
        private static void AddStringParameterToAppender(this AdoNetAppender appender, string paramName,
            int size, string conversionPattern)
        {
            AdoNetAppenderParameter param = new AdoNetAppenderParameter();
            param.ParameterName = paramName;
            param.DbType = System.Data.DbType.String;
            param.Size = size;
            param.Layout = new Layout2RawLayoutAdapter(new PatternLayout(conversionPattern));
            appender.AddParameter(param);
        }
        private static void AddDateTimeParameterToAppender(this AdoNetAppender appender, string paramName)
        {
            AdoNetAppenderParameter param = new AdoNetAppenderParameter();
            param.ParameterName = paramName;
            param.DbType = System.Data.DbType.DateTime;
            param.Layout = new RawUtcTimeStampLayout();
            appender.AddParameter(param);
        }

        private static void AddErrorParameterToAppender(this AdoNetAppender appender, string paramName, int size)
        {
            AdoNetAppenderParameter param = new AdoNetAppenderParameter();
            param.ParameterName = paramName;
            param.DbType = System.Data.DbType.String;
            param.Size = size;
            param.Layout = new Layout2RawLayoutAdapter(new ExceptionLayout());
            appender.AddParameter(param);
        }
    }
}