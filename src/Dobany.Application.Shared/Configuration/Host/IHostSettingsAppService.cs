using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Configuration.Host.Dto;

namespace Dobany.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
