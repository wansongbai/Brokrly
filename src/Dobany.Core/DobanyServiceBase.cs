using Abp;

namespace Dobany
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="DobanyDomainServiceBase"/>.
    /// For application services inherit DobanyAppServiceBase.
    /// </summary>
    public abstract class DobanyServiceBase : AbpServiceBase
    {
        protected DobanyServiceBase()
        {
            LocalizationSourceName = DobanyConsts.LocalizationSourceName;
        }
    }
}