using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.MultiTenancy.Payments.Dto;
using Dobany.MultiTenancy.Payments.Stripe.Dto;

namespace Dobany.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}