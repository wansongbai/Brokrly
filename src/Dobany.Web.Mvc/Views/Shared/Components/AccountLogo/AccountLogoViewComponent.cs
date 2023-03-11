using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Session;

namespace Dobany.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : DobanyViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string skin)
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo, skin));
        }
    }
}
