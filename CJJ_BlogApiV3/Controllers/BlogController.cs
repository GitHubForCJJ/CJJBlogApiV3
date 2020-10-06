using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CJJ.log4netCore;
using CJJ_BlogApiV3.ILogic;
using CJJ_BlogApiV3.Model;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.Model.ReuqestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CJJ_BlogApiV3New.Controllers
{
    /// <summary>
    /// h5博客相关
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBloginfoLogic bloginfoLogic = null;
        private readonly ILogger<BlogController> logger;
        public BlogController(IBloginfoLogic bloginfoLogic,ILogger<BlogController> _logger)
        {
            this.bloginfoLogic = bloginfoLogic;
            logger = _logger;
        }
        /// <summary>
        /// 查询list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResponse> GetList([FromBody] BaseViewModel model)
        {
            try
            {
                //LogManager.Info("GetList进入22  info");
                //LogManager.Error("GetList进入  errorinfo");
                logger.LogDebug("debug message");
                logger.LogInformation("Seeding database...");
                var list = await bloginfoLogic.GetListBloginfo(model);
                return new JsonResponse { Code = 0, Data = list };
            }
            catch (Exception e)
            {
                logger.LogError(e, "BlogController/GetList");
                //Log.Error(e, "BlogController/GetList");
                LogManager.Error("BlogController/GetList" + e.Message, e);
                return new JsonResponse { Code = 1, Msg = "程序错误" + e.Message };
            }
        }


    }
}
