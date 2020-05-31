using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee : DbBaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserAcount { get; set; }
        /// <summary>
        /// 密码MD5
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string UserNikeName { get; set; }

        /// <summary>
        /// 是否为管理员0否，1是
        /// </summary>
        public int IsAdmin { get; set; }
        /// <summary>
        /// 上次重置时间
        /// </summary>
        public DateTime LastUpTime { get; set; }
        /// <summary>
        /// 所属渠道ID,根据不同的企业类型对应不同的渠道ID
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 企业类型,1平台 2高校 3预留
        /// </summary>	
        public int CompanyType { get; set; }
    }
}
