using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model
{
    /// <summary>
    /// 基础返回模型
    /// </summary>
    public class Result
    {
        //
        // 摘要:
        //     成功/失败
        public bool IsSucceed { get; set; }
        //
        // 摘要:
        //     消息
        public string Message { get; set; }
        //
        // 摘要:
        //     错误码，0=无错误
        public int ErrorCode { get; set; }
    }

    /// <summary>
    /// 拓展返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
