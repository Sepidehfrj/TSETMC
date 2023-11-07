using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace TseTmc.Logger
{
   public class Log4netLogger
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(string LogString, Exception exception)
        {
            LogManager.GetLogger("default").Debug("Hello, World!");

            log.Debug(LogString, exception);
        }

        public static void Debug(string userName, string projectName, string bankName, string methodName, string LogString)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Debug(LogString);
        }

        public static void Error(string userName, string projectName, string bankName, string methodName, string LogString, Exception exception)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Error(LogString, exception);
        }

        public static void Error(string userName, string projectName, string bankName, string methodName, string LogString)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Error(LogString);
        }

        public static void Fatal(string userName, string projectName, string bankName, string methodName, string LogString, Exception exception)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Fatal(LogString, exception);
        }

        public static void Fatal(string userName, string projectName, string bankName, string methodName, string LogString)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Fatal(LogString);
        }

        public static void Info(string userName, string projectName, string bankName, string methodName, string LogString, Exception exception)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Info(LogString, exception);
        }

        public static void Info(string userName, string projectName, string bankName, string methodName, string LogString)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Info(LogString);
        }

        public static void Warning(string userName, string projectName, string bankName, string methodName, string LogString, Exception exception)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Warn(LogString, exception);
        }

        public static void Warning(string userName, string projectName, string bankName, string methodName, string LogString)
        {
            LogCustomField(userName, projectName, bankName, methodName);
            log.Warn(LogString);
        }

        private static void LogCustomField(string userName, string projectName, string bankName, string methodName)
        {
            LogUserName(userName);
            LogProjectName(projectName);
            LogBankName(bankName);
            LogMethodName(methodName);
        }
        private static void LogUserName(string userName)
        {
            ThreadContext.Properties["UserName"] = userName;
        }
        private static void LogProjectName(string projectName)
        {
            //MDC.Set("ProjectName", "Melat");
            LogicalThreadContext.Properties["ProjectName"] = projectName;
        }
        private static void LogBankName(string bankName)
        {
            //MDC.Set("BankName", "Melat");
            LogicalThreadContext.Properties["BankName"] = bankName;
        }
        private static void LogMethodName(string methodName)
        {
            LogicalThreadContext.Properties["MethodName"] = methodName;
        }
    }
}
