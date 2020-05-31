using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 博客信息表
    /// </summary>
    public class Bloginfo : DbBaseModel
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
        /// 类型
        /// </summary>      
        public int Type { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>       
        public int IsTop { get; set; }

        /// <summary>
        /// 是否私密不显示
        /// </summary>      
        public int IsPrivate { get; set; }

        /// <summary>
        /// 是否原创
        /// </summary>     
        public int IsOriginal { get; set; }
        /// <summary>
        /// 版本号，乐观锁
        /// </summary>       
        public string Vesion { get; set; }

        /// <summary>
        /// blog图片
        /// </summary>   
        public string Blogimg { get; set; }
        /// <summary>
        /// 序号
        /// </summary>      
        public string Sorc { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>      
        public int Start { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>        
        public int Views { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>       
        public int Comments { get; set; }
    }
}
