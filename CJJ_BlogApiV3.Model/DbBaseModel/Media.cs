using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// Media
    /// </summary>
    public class Media
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
        /// 添加用户
        /// </summary>

        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>

        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户Id
        /// </summary>

        public string UpdateUserId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>

        public string UpdateUserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>

        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 扩展1,
        /// </summary>

        public int Extend1 { get; set; }

        /// <summary>
        /// 扩展2,
        /// </summary>

        public int Extend2 { get; set; }

        /// <summary>
        /// 扩展3,
        /// </summary>

        public int Extend3 { get; set; }

        /// <summary>
        /// 扩展4,
        /// </summary>

        public string Extend4 { get; set; }

        /// <summary>
        /// 扩展5,
        /// </summary>

        public string Extend5 { get; set; }

        /// <summary>
        /// 扩展6,
        /// </summary>

        public string Extend6 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        public string Url { get; set; }

        /// <summary>
        /// 类型,0图片，1视频
        /// </summary>

        public int Type { get; set; }


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
