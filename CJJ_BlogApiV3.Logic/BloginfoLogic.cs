using CJJ_BlogApiV3.ILogic;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJJ_BlogApiV3.Model.ReuqestModel;
using CJJ_BlogApiV3.Model;
using System.Linq.Expressions;
using Go.StandardUtility.Common.Extension;

namespace CJJ_BlogApiV3.Logic
{
    /// <summary>
    /// h5博客相关
    /// </summary>
    public class BloginfoLogic : IBloginfoLogic
    {
        private readonly IBloginfoRepository bloginfoRepository = null;
        public BloginfoLogic(IBloginfoRepository _bloginfoRepository)
        {
            bloginfoRepository = _bloginfoRepository;
        }
        /// <summary>
        /// h5查询博客list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<List<Bloginfo>>> GetListBloginfo(BaseViewModel model)
        {
            Expression<Func<Bloginfo, bool>> selexp = x => x.IsDeleted == 0;
            if (model.KID > 0)
            {

                selexp = selexp.And(x => x.Type == model.KID);
            }
            var listdata = await bloginfoRepository.QueryByPaging(selexp, 0, model.Page, model.Limit);
            return new Result<List<Bloginfo>> { IsSucceed = true, Data = listdata };
        }
    }
}
