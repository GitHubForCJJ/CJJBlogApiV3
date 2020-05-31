using CJJ_BlogApiV3.Model;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.Model.ReuqestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.ILogic
{
    public interface IBloginfoLogic
    {
        Task<Result<List<Bloginfo>>> GetListBloginfo(BaseViewModel model);
    }
}
