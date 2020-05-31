using CJJ_BlogApiV3.IRepository.SqlSugarBase;
using CJJ_BlogApiV3.Model.DbBaseModel;
using CJJ_BlogApiV3.Repository.SqlSugarBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Repository
{
    public class BloginfoRepository : SqlSugarBaseRepository<Bloginfo>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BloginfoRepository(ISqlSugarUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
