using Abp.AutoMapper;
using Dobany.Authorization.Roles.Dto;
using Dobany.Web.Areas.Admin.Models.Common;

namespace Dobany.Web.Areas.Admin.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}