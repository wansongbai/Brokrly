using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobany.Authorization
{
    public enum MyAbpLoginResultType : byte
    {
        /// <summary>
        /// 手机号码未验证
        /// </summary>
        UserMobilePhoneNotConfirmed = 10
    }
}
