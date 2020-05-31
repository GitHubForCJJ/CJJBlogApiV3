using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.ReuqestModel
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseViewModel
    {
        public int KID { get; set; }

        public int Page { get; set; }
        /// <summary>
        /// Gets or sets the limit.
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
