using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Editions.Dto;
using Dobany.MultiTenancy.Dto;

namespace Dobany.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}