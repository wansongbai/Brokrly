using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Authorization.Users;
using Dobany.Authorization.Users;

namespace Dobany.Channels
{
    [Table("AppChannels")]
    public class Channel : Entity<long>, ICreationAudited
    {
        public Channel()
        {
            ChannelId = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }
        public virtual string Name { get; set; }

        public virtual Guid ChannelId { get; set; }

        public virtual string Desc { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual long? CreatorUserId { get; set; }

        public virtual ICollection<User> Members { get; set; } = new List<User>();
    }
}
