using Go.StandardUtility.Common.Encrypt;

using Go.StandardUtility.Tool;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.SetupExtensions
{
    /// <summary>
    /// sqlsugar 拓展
    /// </summary>
    public static class SqlSugarSetup
    {
        /// <summary>
        /// 
        /// </summary>
        public static void AddSqlSugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ISqlSugarClient>(o =>
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = AES.Decrypt(ConfigurationManager.Configuration.GetConnectionString("UserDBWrite")),//必填, 数据库连接字符串
                    //ConnectionString = "server=192.168.10.9;port=3306;user id=root;password=admin;persistsecurityinfo=True;database=go_microshop_user;charset=utf8;AllowUserVariables=True",//必填, 数据库连接字符串
                    DbType = DbType.MySql,//必填, 数据库类型
                    IsAutoCloseConnection = true,//默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                    InitKeyType = InitKeyType.SystemTable,//默认SystemTable, 字段信息读取, 如：该属性是不是主键，标识列等等信息
                    SlaveConnectionConfigs = new List<SlaveConnectionConfig>
                    {
                        new SlaveConnectionConfig() { HitRate=100, ConnectionString= AES.Decrypt(ConfigurationManager.Configuration.GetConnectionString("UserDBRead")) }
                        //new SlaveConnectionConfig() { HitRate=100, ConnectionString= "server=192.168.10.9;port=3306;user id=root;password=admin;persistsecurityinfo=True;database=go_microshop_user;charset=utf8;AllowUserVariables=True" }
                    },
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        SqlFuncServices = Model.GoSqlFunc.GetFlagsEnumExtension()//set ext method
                    }
                });
            });
        }
    }
}
