using System.Collections.Generic;
using Dobany.Authorization.Permissions.Dto;

namespace Dobany.Web.Areas.Admin.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}