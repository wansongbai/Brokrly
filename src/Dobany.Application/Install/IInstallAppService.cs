using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Install.Dto;

namespace Dobany.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}