using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using Dobany.Authorization;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Session;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Components.AdminUserMenu
{
    public class AdminUserMenuViewComponent : DobanyViewComponent
    {
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IAbpSession _abpSession;
        private readonly IPerRequestSessionCache _sessionCache;

        public AdminUserMenuViewComponent(
            IPerRequestSessionCache sessionCache, 
            IMultiTenancyConfig multiTenancyConfig, 
            IAbpSession abpSession)
        {
            _sessionCache = sessionCache;
            _multiTenancyConfig = multiTenancyConfig;
            _abpSession = abpSession;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string togglerCssClass, 
            string textCssClass, 
            string symbolCssClass,
            string symbolTextCssClas,
            bool renderOnlyIcon = false)
        {
            return View(new UserMenuViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                IsImpersonatedLogin = _abpSession.ImpersonatorUserId.HasValue,
                HasUiCustomizationPagePermission = await PermissionChecker.IsGrantedAsync(AppPermissions.Pages_Administration_UiCustomization),
                TogglerCssClass = togglerCssClass,
                TextCssClass = textCssClass,
                SymbolCssClass = symbolCssClass,
                SymbolTextCssClass = symbolTextCssClas,
                RenderOnlyIcon = renderOnlyIcon
            });
        }
    }
}
