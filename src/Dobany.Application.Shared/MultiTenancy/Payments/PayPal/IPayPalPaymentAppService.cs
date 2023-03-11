using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.MultiTenancy.Payments.PayPal.Dto;

namespace Dobany.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
