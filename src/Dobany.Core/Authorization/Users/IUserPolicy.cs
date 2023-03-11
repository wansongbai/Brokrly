using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Dobany.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
