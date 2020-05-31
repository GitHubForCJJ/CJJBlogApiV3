using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    class Comment
    {
        /// <summary>
        /// 会员id
        /// </summary>       
        public string Memberid { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>     
        public string MemberName { get; set; }
        /// <summary>
        /// Blogid
        /// </summary>       
        public string BlogNum { get; set; }
        /// <summary>
        /// 会话id
        /// </summary>
        public string Commentid { get; set; }
        /// <summary>
        /// 评论谁的id  为空指的是自己写的新评论  不为空则是 评论别人的评论
        /// </summary>      
        public string ToMemberid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>     
        public string Content { get; set; }
        /// <summary>
        /// 头像
        /// </summary>      
        public string Avatar { get; set; }
    }
}
