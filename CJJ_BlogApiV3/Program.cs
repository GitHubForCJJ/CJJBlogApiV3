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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog((ctx, config) =>
                //{
                //    config.MinimumLevel.Debug()
                //        .MinimumLevel.Debug()
                //        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                //        .MinimumLevel.Override("System", LogEventLevel.Warning)
                //        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                //        .Enrich.FromLogContext();

                //    if (ctx.HostingEnvironment.IsDevelopment())
                //    {
                //        //config.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}");
                //        config.WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}LogFiles{Path.DirectorySeparatorChar}cjjwebapiv3console.txt",
                //        fileSizeLimitBytes: 1_000_000,
                //        rollOnFileSizeLimit: true,
                //        shared: true,
                //        flushToDiskInterval: TimeSpan.FromSeconds(1));
                //    }
                //    else if (ctx.HostingEnvironment.IsProduction())
                //    {
                //        config.WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}LogFiles{{Path.DirectorySeparatorChar}}cjjwebapiv3.txt",
                //            fileSizeLimitBytes: 1_000_000,
                //            rollOnFileSizeLimit: true,
                //            shared: true,
                //            flushToDiskInterval: TimeSpan.FromSeconds(1));
                //    }
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSerilog((hostingContext, loggerConfiguration) =>
                    {

                        string LogFilePath(string LogEvent) => $@"{AppDomain.CurrentDomain.BaseDirectory}LogFiles\{LogEvent}\log.log";
                        //模板
                        string SerilogOutputTemplate = "{NewLine}{NewLine}Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}LogLevel：{Level}{NewLine}Message：{Message}{NewLine}{Exception}" + new string('-', 50);

                        loggerConfiguration
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                        .MinimumLevel.Override("System", LogEventLevel.Debug)
                        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
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
