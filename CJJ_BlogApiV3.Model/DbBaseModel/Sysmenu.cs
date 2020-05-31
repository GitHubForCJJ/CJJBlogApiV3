using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Sysmenu : DbBaseModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Menuname { get; set; }

        /// <summary>
        /// 菜单备注
        /// </summary>
        public string Menuremark { get; set; }

        /// <summary>
        /// 菜单连接
        /// </summary>
        public string MenuUrl { get; set; }

        /// <summary>
        /// 菜单icon
        /// </summary>
        public string Menuicon { get; set; }

        /// <summary>
        /// 菜单显示顺序
        /// </summary>
        public int Menusort { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        public int Fatherid { get; set; }
    }
}
