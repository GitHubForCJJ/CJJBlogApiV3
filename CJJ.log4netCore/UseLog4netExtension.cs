using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CJJ.log4netCore
{
    public static class UseLog4netExtension
    {
        /// <summary>
        /// 使用log4net配置
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLog4net(this IApplicationBuilder app)
        {
            var logRepository = log4net.LogManager.CreateRepository(System.Reflection.Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XmlConfig\\log4net.config")));
            return app;
        }
    }
}
