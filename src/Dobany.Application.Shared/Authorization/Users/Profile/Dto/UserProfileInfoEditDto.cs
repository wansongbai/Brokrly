using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dobany.Authorization.Users.Profile.Dto
{
    public class UserProfileInfoEditDto
    {
        /// <summary>
        /// 用户简介
        /// </summary>
        [Required]
        public string Profile { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public long UserId { get; set; }
    }
}
