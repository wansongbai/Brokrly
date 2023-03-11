using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Dobany.Authorization.Permissions.Dto;

namespace Dobany.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
