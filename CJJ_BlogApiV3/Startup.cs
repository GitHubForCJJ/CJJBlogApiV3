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
                    Title = "CJJ_BlogApiV3WebApi",   //����
                    Description = "���ǲ���Core����Swagger",
                    Version = "1.0.1", //�汾
                    TermsOfService = new Uri("https://www.baidu.com/"), //"��������"
                    Contact = new OpenApiContact //Api����ϵ��
                    {
                        Name = "WuJinHua",
                        Url = new Uri("https://www.wujinhua.com"),
                        Email = "403062268@qq.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "YaYa",
                        //���֤ǩ��
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
                    //// ȫ���쳣����
                    o.Filters.Add(typeof(GlobalExceptionsFilter));
                    //// ȫ��·��Ȩ�޹�Լ
                    ////o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                    //// ȫ��·��ǰ׺��ͳһ�޸�·��
                    //o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));
                })
             //ȫ������Json���л�����
             .AddNewtonsoftJson(options =>
            {
                    ////����ѭ������
                    //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    ////��ʹ���շ���ʽ��key
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //����ʱ���ʽ
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

            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CJJ_BlogApiV3");
                c.RoutePrefix = string.Empty;
                    //���Ϻ󣬷��ʵ�ַ��https://localhost:44388
                    //c.RoutePrefix = "https://localhost:44388/swagger";//���ʵ�ַ��https://localhost:49382/swagger      
                });
            //app.UseLog4net();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// .netcore3.1 ��autoface����ע��
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
