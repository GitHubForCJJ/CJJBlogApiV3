
using CJJ_BlogApiV3.Model;
using CJJ_BlogApiV3.Model.DbBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ_BlogApiV3.Model.View
{
    [DataContract]
    public class MemberAuthModel : Result
    {
        [DataMember]
        public Member MemberInfo { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
