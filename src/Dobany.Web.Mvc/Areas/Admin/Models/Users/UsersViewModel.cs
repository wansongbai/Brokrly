using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Dobany.Authorization.Permissions.Dto;
using Dobany.Web.Areas.Admin.Models.Common;

namespace Dobany.Web.Areas.Admin.Models.Users
{
    public class UsersViewModel : IPermissionsEditViewModel
    {
        public string FilterText { get; set; }

        public List<ComboboxItemDto> Roles { get; set; }

        public bool OnlyLockedUsers { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}