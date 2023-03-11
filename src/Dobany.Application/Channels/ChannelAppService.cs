using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.ObjectMapping;
using Dobany.Authorization.Users;
using Dobany.Channels.Dto;
using Dobany.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dobany.Channels
{
    [AbpAuthorize]
    public class ChannelAppService : AsyncCrudAppService<Channel, ChannelDto, long>, IChannelAppService
    {
        private readonly IDbContextProvider<DobanyDbContext> _dbContextProvider;
        private readonly IRepository<Channel, long> _channelRepository;
        private readonly IObjectMapper _objectMapper;

        public UserManager UserManager { get; set; }

        public ChannelAppService(
            IDbContextProvider<DobanyDbContext> dbContextProvider,
            IRepository<Channel, long> channelRepository,
            IObjectMapper objectMapper
            ) : base(channelRepository)
        {
            _dbContextProvider = dbContextProvider;
            _channelRepository = channelRepository;
            _objectMapper = objectMapper;
        }
        [UnitOfWork()]
        [HttpPost]
        public async Task<ChannelDto> CreateChannel(ChannelDto channelInput)
        {
            string channelName = channelInput.Name;
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentNullException(channelName);
            }
            var user = UserManager.GetUserById(AbpSession.UserId.Value);

            var channel = new Channel()
            {
                CreationTime = DateTime.Now,
                Name = channelName,
                Members = new List<User>
                {
                    user
                }
            };

            channel.CreatorUserId = AbpSession.UserId;
            var chan = await _channelRepository.InsertAsync(channel);
            await _dbContextProvider.GetDbContext().SaveChangesAsync();
            var dto = _objectMapper.Map<ChannelDto>(chan);
            return dto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="memberId">成员用户id</param>
        /// <param name="exit">退出频道传1，默认为加入频道</param>
        /// <returns></returns>
        [UnitOfWork()]
        [HttpPost]
        public async Task<ChannelDto> UpdateMember(long channelId, long memberId, bool exit)
        {
            var chan = Repository.GetAll().Include(nameof(Channel.Members)).FirstOrDefault(x => x.Id == channelId);

            if (exit)
            {
                var list = chan.Members.ToList();
                list.RemoveAll(x => x.Id == memberId);
                chan.Members = list;
            }
            else
            {
                var user = UserManager.GetUserById(memberId);
                chan.Members.Add(user);
            }

            await _channelRepository.UpdateAsync(chan);
            var dto = _objectMapper.Map<ChannelDto>(chan);
            return dto;
        }

        protected override IQueryable<Channel> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAll().Include(nameof(Channel.Members)).Where(x => x.Members.Count > 0);
        }

        //public override async Task<PagedResultDto<ChannelDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        //{
        //    var result = await base.GetAllAsync(input);
        //    return result;
        //}
    }
}
