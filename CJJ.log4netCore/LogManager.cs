using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CJJ.log4netCore
{
    public class LogManager
    {
        private static ILog logger;
        private static ILoggerRepository loggerRepository { get; set; }
        static LogManager()
        {
            loggerRepository = log4net.LogManager.CreateRepository("NETCoreLog4netRepository");
            var file = new FileInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XmlConfig\\log4net.config"));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, file);
            logger = log4net.LogManager.GetLogger("NETCoreLog4netRepository", "loginfo");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configpath">配置地址 全路径</param>
        // static LogManager(string configpath)
        //{
        //    loggerRepository = log4net.LogManager.CreateRepository("NETCoreLog4netRepository");
        //    var file = new FileInfo(configpath);
        //    log4net.Config.XmlConfigurator.Configure(loggerRepository, file);
        //    logger = log4net.LogManager.GetLogger("NETCoreLog4netRepository", "loginfo");
        //}
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Info(message);
            else
                logger.Info(message, exception);
        }

        /// <summary>
        /// 告警日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Warn(message);
            else
                logger.Warn(message, exception);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null)
        {
            if (exception == null)
                logger.Error(message);
            else
                logger.Error(message, exception);
        }
    }
}
