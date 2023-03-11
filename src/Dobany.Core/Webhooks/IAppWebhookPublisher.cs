using System.Threading.Tasks;
using Dobany.Authorization.Users;

namespace Dobany.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
