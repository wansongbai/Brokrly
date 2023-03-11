using AgoraIO.Media;
using AgoraIO.Rtm;
using Dobany.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobany.Agora.Authentication
{
    public class AgoraAuthService : DobanyAppServiceBase, IAgoraAuthService
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string _appId;
        private readonly string _appCertificate;

        public AgoraAuthService(IWebHostEnvironment env)
        {
            _hostingEnvironment = env;
            _appConfiguration = env.GetAppConfiguration();

            _appId = _appConfiguration["Agora:AppId"];
            _appCertificate = _appConfiguration["Agora:AppCert"];
        }
        public Task<string> GetRtmToken(string account, string channelName, int privilege, uint ts = 1111111, uint salt = 1, uint expire = 0)
        {
            uint expireTimestamp = expire == 0 ? (uint)((DateTime.Now.AddHours(2).ToUniversalTime().Ticks - 621355968000000000) / 10000000) : expire;

            var builder = new RtmTokenBuilder();
            builder.setPrivilege((Privileges)privilege, expireTimestamp);
            var result = builder.buildToken(_appId, _appCertificate, account);

            return Task.FromResult(result);
        }

        public Task<String> GetRtcToken(string account, string channelName, uint role, int privilege, uint ts = 1111111, uint salt = 1, uint expire = 0)
        {
            uint expireTimestamp = expire == 0 ? (uint)((DateTime.Now.AddHours(2).ToUniversalTime().Ticks - 621355968000000000) / 10000000) : expire;

            RtcTokenBuilder builder = new RtcTokenBuilder();
            string result = builder.buildTokenWithUserAccount(_appId, _appCertificate, channelName, account, (RtcTokenBuilder.Role)role, expireTimestamp);

            return Task.FromResult(result);
        }
    }
}
