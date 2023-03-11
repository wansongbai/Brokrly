using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dobany.Authorization.Permissions.Dto;

namespace Dobany.Web.Areas.Admin.Models.Common.Modals
{
    public class PermissionTreeModalViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }
        public List<string> GrantedPermissionNames { get; set; }
    }
}
