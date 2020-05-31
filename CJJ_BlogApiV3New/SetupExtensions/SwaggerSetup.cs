using CJJ.log4netCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CJJ_BloCJJ_BlogApiV3NewgApiV3.SetupExtensions
{
    public static class SwaggerSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1.0.0",
                    Title = "CJJ_BlogApiV3New",
                    Description = "用户Api说明文档",
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "CJJ_BlogApiV3New.xml");
                c.IncludeXmlComments(xmlPath, true);
                xmlPath = Path.Combine(basePath, "CJJ_BlogApiV3New.xml");
                c.IncludeXmlComments(xmlPath);



                //c.OperationFilter<AddResponseHeadersFilter>();
                //c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //c.OperationFilter<SecurityRequirementsOperationFilter>();

                //// Token绑定到ConfigureServices
                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = SecuritySchemeType.ApiKey
                //});
            });
        }
    }
}
