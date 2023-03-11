using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Session;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Themes.Default.Components.AdminDefaultFooter
{
    public class AdminDefaultFooterViewComponent : DobanyViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AdminDefaultFooterViewComponent(IPerRequestSessionCache sessionCache)
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
