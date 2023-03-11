using System.Collections.Generic;
using Dobany.Editions.Dto;

namespace Dobany.Web.Areas.Admin.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}