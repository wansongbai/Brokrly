using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Dobany.WebHooks.Dto;

namespace Dobany.Web.Areas.Admin.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
