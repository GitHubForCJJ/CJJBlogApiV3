using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using CJJ.log4netCore;
using CJJ_BlogApiV3.Filter;
using CJJ_BlogApiV3.Quartz;
using CJJ_BlogApiV3.SetupExtensions;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace CJJ_BlogApiV3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddQuartz(typeof(QuartzJob));
            //services.AddSwaggerSetup();

            services.AddSwaggerGen(operation =>
            {
                operation.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CJJ_BlogApiV3WebApi",   //标题
                    Description = "这是测试Core引入Swagger",
                    Version = "1.0.1", //版本
                    TermsOfService = new Uri("https://www.baidu.com/"), //"服务条款"
                    Contact = new OpenApiContact //Api的联系人
                    {
                        Name = "WuJinHua",
                        Url = new Uri("https://www.wujinhua.com"),
                        Email = "403062268@qq.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "YaYa",
                        //许可证签名
                        Url = new Uri("https://www.YaYa.com/")
                    }
                });
            });



            services.AddSqlSugarSetup();
            //services.AddSingleton(typeof(LogManager));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = Configuration.GetSection("IdentityServerUrl").Value;
                options.ApiName = "openauthapi";
                options.RequireHttpsMetadata = false;
            });

            services.AddControllers(o =>
            {
                    //// 全局异常过滤
                    o.Filters.Add(typeof(GlobalExceptionsFilter));
                    //// 全局路由权限公约
                    ////o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                    //// 全局路由前缀，统一修改路由
                    //o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));
                })
             //全局配置Json序列化处理
             .AddNewtonsoftJson(options =>
            {
                    ////忽略循环引用
                    //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    ////不使用驼峰样式的key
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //设置时间格式
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    //options.SerializerSettings.Converters.
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            //QuartzService.StartJob<QuartzJob>();

            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CJJ_BlogApiV3");
                c.RoutePrefix = string.Empty;
                    //加上后，访问地址：https://localhost:44388
                    //c.RoutePrefix = "https://localhost:44388/swagger";//访问地址：https://localhost:49382/swagger      
                });
            //app.UseLog4net();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// .netcore3.1 下autoface程序集注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Logic.BloginfoLogic).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Repository.BloginfoRepository).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType(typeof(LogManager));
        }
    }
}
