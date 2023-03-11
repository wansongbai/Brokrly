using Abp.Application.Services;
using Dobany.Channels.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobany.Channels
{
    public interface IChannelAppService : IApplicationService
    {
        Task<ChannelDto> CreateChannel(ChannelDto channelInput);

        Task<ChannelDto> UpdateMember(long channelId, long memberId, bool exit);
    }
}
