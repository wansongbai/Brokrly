using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobany.Dto
{
    public class UserDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual string UserName { get; set; }

        public virtual Guid? ProfilePictureId { get; set; }

        public virtual string Avatar { get; set; }

        public virtual string NickName { get; set; }
    }
}
