using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Session;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Themes.Theme9.Components.AdminTheme9Brand
{
    public class AdminTheme9BrandViewComponent : DobanyViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AdminTheme9BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
