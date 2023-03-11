using System.Collections.Generic;
using Dobany.Editions.Dto;
using Dobany.MultiTenancy.Payments;

namespace Dobany.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}