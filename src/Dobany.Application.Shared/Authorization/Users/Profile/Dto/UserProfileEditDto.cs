using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dobany.Authorization.Users.Profile.Dto
{
    /// <summary>
    /// 更新用户昵称实体
    /// </summary>
    public class UserProfileEditDto
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string NickName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public long UserId { get; set; }
    }
}
