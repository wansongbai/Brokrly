using Abp.Application.Services;
using Dobany.Dto;
using Dobany.Logging.Dto;

namespace Dobany.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
