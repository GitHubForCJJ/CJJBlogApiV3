using CJJ.log4netCore;
using Go.StandardUtility.Common.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        public void OnException(ExceptionContext context)
        {
            //LogManager.Error( "全局异常",context.Exception);
            context.Result = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json;charset=UTF-8",
                Content = new
                {
                    errorCode = 500,
                    isSucceed = false,
                    message = context.Exception.Message.ToString(),
                }.SerializeObject(),
            };
            context.ExceptionHandled = true;
        }
    }
}
