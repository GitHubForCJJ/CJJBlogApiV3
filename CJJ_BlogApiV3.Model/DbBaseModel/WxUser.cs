using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Model.DbBaseModel
{
    /// <summary>
    /// 微信用户
    /// </summary>
    public class WxUser : DbBaseModel
    {
        public string Openid { get; set; }

        public string NickName { get; set; }

        public string Sex { get; set; }
        /// <summary>
        /// 用户个人资料填写的省份
        /// </summary>

        public string Province { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>

        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom
        /// </summary>

        public string Privilege { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>

        public string Unionid { get; set; }
    }
}
