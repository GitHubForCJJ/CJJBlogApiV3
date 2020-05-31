using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 博客分类
    /// </summary>
    public class Category : DbBaseModel
    {
        /// <summary>
        /// 父id
        /// </summary>
        public int FatherId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否私密不显示
        /// </summary>
        public int Description { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
