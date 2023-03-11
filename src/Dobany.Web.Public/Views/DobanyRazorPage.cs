using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Dobany.Web.Public.Views
{
    public abstract class DobanyRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected DobanyRazorPage()
        {
            LocalizationSourceName = DobanyConsts.LocalizationSourceName;
        }
    }
}
