﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model
{
    /// <summary>
    /// 请求类
    /// </summary>
    public class JsonRequest
    {
        /// <summary>
        /// 接口请求类型
        /// </summary>
        public int App { get; set; }
        /// <summary>
        /// 请求数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 校验值
        /// </summary>
        public string Md5 { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public double Timestamp { get; set; }
        /// <summary>
        /// 登录token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int Limit { get; set; }
    }
}
