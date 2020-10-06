using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace CJJ_BlogApiV3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test();
            CreateHostBuilder(args).Build().Run();
        }
        public static void Test()
        {
            List<string> model = new List<string>
            {
                "20202000123",
                "20200600222",
                "20201400235","2020660124"
            };
            var tt=model.GroupBy(x=>x.Substring(6,2));
            foreach(var item in tt)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog((hostingContext, loggerConfiguration) =>
                    {
                        string LogFilePath(string LogEvent) => $@"{AppDomain.CurrentDomain.BaseDirectory}LogFiles\{LogEvent}\log.log";
                        //模板
                        string SerilogOutputTemplate = "{NewLine}{NewLine}Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}LogLevel：{Level}{NewLine}Message：{Message}{NewLine}{Exception}" + new string('-', 50);

                        loggerConfiguration
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                        .MinimumLevel.Override("System", LogEventLevel.Debug)
                       // .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                        .Enrich.FromLogContext()

                       .ReadFrom.Configuration(hostingContext.Configuration)
                       .Enrich.FromLogContext()
                       //.WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}LogFiles{Path.DirectorySeparatorChar}cjjapi.txt", rollingInterval: RollingInterval.Day)
                       //不同类型的日志写到不同的文件夹中
                       .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Debug).WriteTo.File(LogFilePath("Debug"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
.WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information).WriteTo.File(LogFilePath("Information"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
.WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Warning).WriteTo.File(LogFilePath("Warning"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
.WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error).WriteTo.File(LogFilePath("Error"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))
.WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Fatal).WriteTo.File(LogFilePath("Fatal"), rollingInterval: RollingInterval.Day, outputTemplate: SerilogOutputTemplate))

                       .WriteTo.Console();
                    });
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());//替换原有的IOC容器
    }
}
