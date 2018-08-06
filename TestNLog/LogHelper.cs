using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace TestNLog
{
    public class LogHelper
    {
        NLog.Logger logger;
        private static string _loggerName = "LnProcessDBLog";

        private LogHelper(NLog.Logger logger)
        {
            this.logger = logger;
        } 
        public static LogHelper Default { get; private set; }
        public static LogHelper DBDefault { get; private set; }
        static LogHelper()
        {
            Default = new LogHelper(NLog.LogManager.GetCurrentClassLogger());
            DBDefault= new LogHelper(NLog.LogManager.GetLogger(_loggerName));
        }
        public void Log(string message, string logContent,Exception err=null)
        {
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Trace, message, logContent);
            theEvent.Properties["LogContent"] = logContent;
            theEvent.Properties["Message"] = message;
            theEvent.Properties["StackTrace"] = err?.StackTrace;
            logger.Log(theEvent);
           
        }

        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            logger.Debug(err, msg);
        }

        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            logger.Info(err, msg);
        }

        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            logger.Trace(err, msg);
        }

        public void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            string errstr = string.Empty;
            errstr += msg + "\r\n";
            errstr += "source:" + err.Source + "\r\n";
            errstr += "stackTrace:" + err.StackTrace;
            logger.Error(err, errstr);
        }
       
        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            logger.Fatal(err, msg);
        }
    }
}
