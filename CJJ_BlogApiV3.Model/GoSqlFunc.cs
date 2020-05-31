using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class GoSqlFunc
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SqlFuncExternal> GetFlagsEnumExtension()
        {
            var expMethods = new List<SqlFuncExternal>();
            expMethods.Add(new SqlFuncExternal()
            {
                UniqueMethodName = "BitAnd",
                MethodValue = (expInfo, dbType, expContext) =>
                {
                    if (dbType == DbType.MySql)
                        return string.Format("({0} & {1} = {1})", expInfo.Args[0].MemberName, expInfo.Args[1].MemberName);
                    else
                        throw new Exception("未实现");
                }
            });
            expMethods.Add(new SqlFuncExternal()
            {
                UniqueMethodName = "BitOr",
                MethodValue = (expInfo, dbType, expContext) =>
                {
                    if (dbType == DbType.MySql)
                        return string.Format("({0} | {1} = {1})", expInfo.Args[0].MemberName, expInfo.Args[1].MemberName);
                    else
                        throw new Exception("未实现");
                }
            });
            return expMethods;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static bool BitAnd(int val, int flags)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static bool BitOr(int val, int flags)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }
    }
}
