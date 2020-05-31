using System;
using CJJ_BlogApiV3.Filter;
using CJJ_BlogApiV3.SetupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CJJ_BlogApiV3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerSetup();
            services.AddSqlSugarSetup();
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
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
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //����ʱ���ʽ
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    //options.SerializerSettings.Converters.
                });

            //var builder = new ContainerBuilder();
            //builder.Populate(services);
            ////builder.RegisterAssemblyTypes(typeof(BloginfoLogic).Assembly).AsImplementedInterfaces();
            ////builder.RegisterAssemblyTypes(typeof(BloginfoRepository).Assembly).AsImplementedInterfaces();
            //ConfigureContainer(builder);
            //var Container = builder.Build();
            //return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp v1");
                c.RoutePrefix = "";
            });

            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Logic.BloginfoLogic).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(Repository.BloginfoRepository).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
