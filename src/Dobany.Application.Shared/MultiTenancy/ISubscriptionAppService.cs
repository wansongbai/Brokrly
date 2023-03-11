using System.Threading.Tasks;
using Abp.Application.Services;

namespace Dobany.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
