using Abp.AutoMapper;
using Dobany.Authorization.Users;
using Dobany.Authorization.Users.Dto;
using Dobany.Web.Areas.Admin.Models.Common;

namespace Dobany.Web.Areas.Admin.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}