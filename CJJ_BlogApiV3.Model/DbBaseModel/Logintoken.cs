using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 登录token  暂时这样
    /// </summary>
    public class Logintoken
    {
        /// <summary>
        /// 编号,数据库自增本表唯一
        /// </summary>
        public int KID { get; set; }
        /// <summary>
        /// 状态,0正常数据 1已禁用
        /// </summary>
        public int States { get; set; }
        /// <summary>
        /// 删除,0未删除 1已删除
        /// </summary>
        public int IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token有效期到期时间
        /// </summary>
        public string TokenExpiration { get; set; }

        /// <summary>
        /// 登录者id
        /// </summary>
        public string LoginUserId { get; set; }

        /// <summary>
        /// 登录人的账号
        /// </summary>
        public string LoginUserAccount { get; set; }

        /// <summary>
        /// 登录账户类型
        /// </summary>
        public int LoginUserType { get; set; }

        /// <summary>
        /// 登录设备ip
        /// </summary>
        public string IpAddr { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        public int PlatForm { get; set; }

        /// <summary>
        /// 是否退出登录0未退，1退出
        /// </summary>
        public int IsLogOut { get; set; }

        /// <summary>
        /// 登录结果
        /// </summary>
        public string LoginResult { get; set; }

    }
}
