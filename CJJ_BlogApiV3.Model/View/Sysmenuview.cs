using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    public class Sysmenuview
    {

        /// <summary>
        /// 编号,数据库自增本表唯一
        /// </summary>
        public int KID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Menuname { get; set; }

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
