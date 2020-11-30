
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.Model.View
{
    /// <summary>
    /// 上下篇
    /// </summary>
    public class PrenextView : Result
    {
        public PrenextViewItem PreBlog { get; set; }
        public PrenextViewItem NextBlog { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PrenextViewItem
    {
        public int KID { get; set; }
        public string BlogNum { get; set; }
        public string Title { get; set; }

    }

}
