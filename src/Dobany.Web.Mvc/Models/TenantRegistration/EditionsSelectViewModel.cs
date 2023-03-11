using Abp.AutoMapper;
using Dobany.MultiTenancy.Dto;

namespace Dobany.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
