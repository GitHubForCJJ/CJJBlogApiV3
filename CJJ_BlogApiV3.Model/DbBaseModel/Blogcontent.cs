using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 博客内容
    /// </summary>
    public class Blogcontent : DbBaseModel
    {
        /// <summary>
        /// 基本信息编号
        /// </summary>
        public string BloginfoNum { get; set; }

        /// <summary>
        /// 博客内容  url编码处理
        /// </summary>
        public string Content { get; set; }
    }
}
