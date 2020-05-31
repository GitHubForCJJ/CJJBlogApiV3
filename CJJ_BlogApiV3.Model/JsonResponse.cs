using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model
{
    /// <summary>
    /// 返回类
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// 0成功 其它失败
        /// </summary>
        public int Code { get; set; }
        public int Count { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
