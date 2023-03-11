using System.Collections.Generic;
using Dobany.Authorization.Users.Dto;

namespace Dobany.Web.Areas.Admin.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}