using Dobany.Editions;
using Dobany.Editions.Dto;
using Dobany.MultiTenancy.Payments;
using Dobany.Security;
using Dobany.MultiTenancy.Payments.Dto;

namespace Dobany.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
