using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.Mapper
{
    public class BloginfoView
    {
        /// <summary>
        /// 博客编号
        /// </summary>        
        public string BlogNum { get; set; }
        /// <summary>
        /// 标题
        /// </summary>       
        public string Title { get; set; }
        /// <summary>
        /// 编号,数据库自增本表唯一
        /// </summary>
        public int KID { get; set; }

    }
}
