using Abp.Application.Services.Dto;
using Dobany.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobany.Channels.Dto
{
    public class ChannelDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ChannelId { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public List<UserDto> Members { get; set; }
    }
}
