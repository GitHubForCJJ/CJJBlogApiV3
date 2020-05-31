using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CJJ_BlogApiV3New
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
            services.AddControllers();
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1.0.0",
                    Title = "CJJ_BlogApiV3New",
                    Description = "用户Api说明文档",
                });

                try
                {
                    var basePath = AppContext.BaseDirectory;
                    var xmlPath = Path.Combine(basePath, "CJJ_BlogApiV3New.xml");
                    c.IncludeXmlComments(xmlPath, true);
                    xmlPath = Path.Combine(basePath, "CJJ_BlogApiV3New.xml");
                    c.IncludeXmlComments(xmlPath);
                }
                catch (Exception e)
                {
                    // LogManager.Error("读取模型xml文件失败，swagger可能不会展示部分注释", e);
                }
                // 为 Swagger JSON and UI设置xml文档注释路径
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

            app.UseAuthorization();
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //加上后，访问地址：https://localhost:44388
                //c.RoutePrefix = "https://localhost:44388/swagger";//访问地址：https://localhost:49382/swagger      
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
