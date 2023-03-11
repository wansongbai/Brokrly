using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Dobany.Configuration.Tenants.Dto;

namespace Dobany.Web.Areas.Admin.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
        
        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}