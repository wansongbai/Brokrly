using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Dobany.Authorization.Permissions.Dto;
using Dobany.Web.Areas.Admin.Models.Common;

namespace Dobany.Web.Areas.Admin.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}