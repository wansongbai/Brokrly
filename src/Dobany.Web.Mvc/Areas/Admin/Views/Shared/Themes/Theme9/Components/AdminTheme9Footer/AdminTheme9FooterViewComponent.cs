using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Session;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Themes.Theme9.Components.AdminTheme9Footer
{
    public class AdminTheme9FooterViewComponent : DobanyViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AdminTheme9FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
