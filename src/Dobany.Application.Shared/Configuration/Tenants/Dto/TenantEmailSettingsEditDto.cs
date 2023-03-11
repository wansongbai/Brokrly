using Abp.Auditing;
using Dobany.Configuration.Dto;

namespace Dobany.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}