using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 文章点赞
    /// </summary>
    public class ArticlePraise : DbBaseModel
    {
        /// <summary>
        /// 会员id
        /// </summary> 
        public string MemberId { get; set; }
        /// <summary>
        /// 文章编号
        /// </summary>    
        public string BlogNum { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }
    }
}
