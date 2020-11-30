using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model
{
    /// <summary>
    /// 返回基础类
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// 0成功 其它失败
        /// </summary>
        public int Code { get; set; }
        public int Count { get; set; }
        public string Msg { get; set; }
    }
    /// <summary>
    /// 单个返回实体
    /// </summary>
    public class JsonResponse<T> : JsonResponse
    {
        public T Data { get; set; }
    }
    /// <summary>
    /// list数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonListResponse<T> : JsonResponse
    {
        /// <summary>
        /// list数据
        /// </summary>
        public List<T> Data { get; set; }
    }
}
