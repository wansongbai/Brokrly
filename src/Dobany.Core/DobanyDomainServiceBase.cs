using Abp.Domain.Services;

namespace Dobany
{
    public abstract class DobanyDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected DobanyDomainServiceBase()
        {
            LocalizationSourceName = DobanyConsts.LocalizationSourceName;
        }
    }
}
