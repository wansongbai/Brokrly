using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobany.Agora.Authentication
{
    public interface IAgoraAuthService : IApplicationService
    {
        Task<string> GetRtmToken(string account, string channelName, int privilege, uint ts, uint salt, uint expire);
        Task<string> GetRtcToken(string account, string channelName, uint role, int privilege, uint ts, uint salt, uint expire);
    }
}
