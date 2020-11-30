using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CJJ.log4netCore;
using CJJ_BlogApiV3.ILogic;
using CJJ_BlogApiV3.Model;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.Model.Mapper;
using CJJ_BlogApiV3.Model.ReuqestModel;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<JsonListResponse<BloginfoView>> GetListBlog([FromBody] BaseViewModel model)
        {
            try
            {
                var list = await bloginfoLogic.GetListBloginfo(model);
                var dlist = list?.Data.MapToList<BloginfoView>();
                return new JsonListResponse<BloginfoView> { Code = 0, Data = dlist };
            }
            catch (Exception e)
            {
                logger.LogError(e, "BlogController/GetListBlog");
                return new JsonListResponse<BloginfoView> { Code = 1, Msg = "程序错误" + e.Message };
            }
        }


    }
}
