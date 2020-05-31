using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    ///  访问记录表
    /// </summary>
    public class Access : DbBaseModel
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 博客编号
        /// </summary>
        public string BlogNum { get; set; }
        /// <summary>
        /// 博客名称
        /// </summary>
        public string BlogName { get; set; }
        /// <summary>
        /// 查看类型 0首页 1单个博客
        /// </summary>
        public int AccessType { get; set; }
    }
}
