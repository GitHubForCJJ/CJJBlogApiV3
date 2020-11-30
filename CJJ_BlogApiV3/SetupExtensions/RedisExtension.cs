using CJJ.Redis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.SetupExtensions
{
    /// <summary>
    /// redis 拓展
    /// </summary>
    public static class RedisExtension
    {
        /// <summary>
        /// 添加redis
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_connectionString">字符串</param>
        /// <param name="_instanceName">实例名称</param>
        /// <param name="_defaultDB">默认数据库</param>
        public static void AddRedisExtension(this IServiceCollection service,string _connectionString,string _instanceName, int _defaultDB)
        {
            //redis缓存
            //var section = Configuration.GetSection("Redis:Default");
            ////连接字符串
            //string _connectionString = section.GetSection("Connection").Value;
            ////实例名称
            //string _instanceName = section.GetSection("InstanceName").Value;
            ////默认数据库 
            //int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
            service.AddSingleton(new RedisHelper(_connectionString, _instanceName, _defaultDB));
        }
    }
}
