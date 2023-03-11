using Abp.AspNetCore.Mvc.Views;

namespace Dobany.Web.Views
{
    public abstract class DobanyRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected DobanyRazorPage()
        {
            LocalizationSourceName = DobanyConsts.LocalizationSourceName;
        }
    }
}
