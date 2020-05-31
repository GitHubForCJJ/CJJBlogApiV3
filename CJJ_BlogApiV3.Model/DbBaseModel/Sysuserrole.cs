using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
	/// <summary>
	/// 员工角色关联
	/// </summary>
    public class Sysuserrole
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
		/// 用户id
		/// </summary>
		public string Userid { get; set; }

		/// <summary>
		/// 角色id
		/// </summary>
		public string Roleid { get; set; }

		/// <summary>
		/// 0员工，1是会员
		/// </summary>
		public int UserType { get; set; }
	}
}
