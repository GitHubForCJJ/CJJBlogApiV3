using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Sysrole : DbBaseModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Rolename { get; set; }

        /// <summary>
        /// 角色备注
        /// </summary>
        public string Roleremark { get; set; }

        /// <summary>
        /// 菜单ID，逗号分隔
        /// </summary>
        public string MenuList { get; set; }
    }
}
