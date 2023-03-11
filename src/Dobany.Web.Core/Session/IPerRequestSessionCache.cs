using System.Threading.Tasks;
using Dobany.Sessions.Dto;

namespace Dobany.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
