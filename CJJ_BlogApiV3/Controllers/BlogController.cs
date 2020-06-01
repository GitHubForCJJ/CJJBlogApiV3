using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CJJ.log4netCore;
using CJJ_BlogApiV3.ILogic;
using CJJ_BlogApiV3.Model;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.Model.ReuqestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public BlogController(IBloginfoLogic bloginfoLogic)
        {
            this.bloginfoLogic = bloginfoLogic;
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
                var list = await bloginfoLogic.GetListBloginfo(model);
                return new JsonResponse { Code = 0, Data = list };
            }
            catch (Exception e)
            {
                LogManager.Error("BlogController/GetList" + e.Message, e);
                return new JsonResponse { Code = 1, Msg = "程序错误" + e.Message };
            }
        }
    }
}
