using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.ReuqestModel
{
    /// <summary>
    /// 基本查询model
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int KID { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>

        public int Page { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public int Limit { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Num { get; set; }
    }
}
