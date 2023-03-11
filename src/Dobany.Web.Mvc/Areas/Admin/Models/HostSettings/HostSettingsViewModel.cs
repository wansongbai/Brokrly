using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Dobany.Configuration.Host.Dto;
using Dobany.Editions.Dto;

namespace Dobany.Web.Areas.Admin.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}