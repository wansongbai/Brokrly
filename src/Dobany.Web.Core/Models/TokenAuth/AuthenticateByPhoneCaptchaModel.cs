using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobany.Web.Models.TokenAuth
{
    /// <summary>
    /// 注册（登录）传参模型
    /// </summary>
    public class AuthenticateByPhoneCaptchaModel
    {
        /// <summary>
        /// 昵称 对应数据库（NickName） - 首次登录时传入即可
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        public string Captcha { get; set; }
    }
}
