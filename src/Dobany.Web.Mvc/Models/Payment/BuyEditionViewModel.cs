using System.Collections.Generic;
using Dobany.Editions;
using Dobany.Editions.Dto;
using Dobany.MultiTenancy.Payments;
using Dobany.MultiTenancy.Payments.Dto;

namespace Dobany.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
