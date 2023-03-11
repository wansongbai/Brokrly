using System.Threading.Tasks;
using Abp.Webhooks;

namespace Dobany.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
