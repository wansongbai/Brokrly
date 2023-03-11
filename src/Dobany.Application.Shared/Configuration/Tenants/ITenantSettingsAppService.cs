using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Configuration.Tenants.Dto;

namespace Dobany.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
