using Abp.AspNetCore.Mvc.ViewComponents;

namespace Dobany.Web.Public.Views
{
    public abstract class DobanyViewComponent : AbpViewComponent
    {
        protected DobanyViewComponent()
        {
            LocalizationSourceName = DobanyConsts.LocalizationSourceName;
        }
    }
}