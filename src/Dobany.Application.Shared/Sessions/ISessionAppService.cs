﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Sessions.Dto;

namespace Dobany.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
