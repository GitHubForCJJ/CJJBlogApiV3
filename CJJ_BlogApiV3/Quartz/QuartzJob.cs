using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using CJJ.log4netCore;

namespace CJJ_BlogApiV3.Quartz
{
    public class QuartzJob : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            var jobKey = context.JobDetail.Key;//获取job信息
            var triggerKey = context.Trigger.Key;//获取trigger信息
            var time = GetTime();
            //string t1 = "2";
            (string t1, string t2, string t3) = GetstringABC();
            Console.WriteLine($"{time.Item1} QuartzJob:==>>自动执行.{jobKey.Name}|{triggerKey.Name}{time.end}");
            Log.Information($"{DateTime.Now} QuartzJob:==>>自动执行.{jobKey.Name}|{triggerKey.Name}");

            {
                string a = "2";
            }
            await Task.CompletedTask;
        }
        public (DateTime begin, DateTime end) GetTime()
        {
            return (DateTime.Now, DateTime.Now.AddDays(2));
        }
        public (string a, string b, string c) GetstringABC()
        {
            return ("aa", "bb", "cc");
        }
        public Tuple<string,string,string> Getstring()
        {
             return new Tuple<string, string, string>("aa", "bb", "cc");
        }
    }
}
