using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
	/// <summary>
	/// 日志
	/// </summary>
    public class Fd_sys_operationlog
    {
		/// <summary>
		/// 序号,ID自增编号,本表唯一
		/// </summary>
		public int KID { get; set; }
		/// <summary>
		/// 数据状态,0启用 1禁用
		/// </summary>
		public int States { get; set; }
		/// <summary>
		/// 状态,0未删除 1已删除
		/// </summary>
		public int Deleted { get; set; }
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
		/// 数据对象,可以存储表名
		/// </summary>
		public string TableName { get; set; }
		/// <summary>
		/// 对象主键,操作对象的主键字段名称 默认KID
		/// </summary>
		public string TablePriKeyField { get; set; }
		/// <summary>
		/// 主键值,操作对象数据的值
		/// </summary>
		public string TablePriKeyValue { get; set; }

		/// <summary>
		/// 操作者IP地址
		/// </summary>
		public string IpAddr { get; set; }
		/// <summary>
		/// 请求数据,方便查看对象 可以为Json对象
		/// </summary>
		public string ReqData { get; set; }
		/// <summary>
		/// 操作前数据内容,Json对象
		/// </summary>
		public string ResOldData { get; set; }

		/// <summary>
		/// 操作后数据结果,Json对象,操作前后 数据记录
		/// </summary>
		public string ResResult { get; set; }
		/// <summary>
		/// 日志类型,1添加 2编辑 3修改 4常规日志
		/// </summary>
		public int OperType { get; set; }

		/// <summary>
		/// 操作结果,0成功 1失败 
		/// </summary>
		public int OperResult { get; set; }

		/// <summary>
		/// 日志内容
		/// </summary>
		public string LogContent { get; set; }
	}
}
