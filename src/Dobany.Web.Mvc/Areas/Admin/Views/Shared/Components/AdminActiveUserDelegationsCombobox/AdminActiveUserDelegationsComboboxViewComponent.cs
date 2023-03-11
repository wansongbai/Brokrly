using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Authorization.Delegation;
using Dobany.Authorization.Users.Delegation;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Components.AdminActiveUserDelegationsCombobox
{
    public class AdminActiveUserDelegationsComboboxViewComponent : DobanyViewComponent
    {
        private readonly IUserDelegationAppService _userDelegationAppService;
        private readonly IUserDelegationConfiguration _userDelegationConfiguration;

        public AdminActiveUserDelegationsComboboxViewComponent(
            IUserDelegationAppService userDelegationAppService, 
            IUserDelegationConfiguration userDelegationConfiguration)
        {
            _userDelegationAppService = userDelegationAppService;
            _userDelegationConfiguration = userDelegationConfiguration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null, string logoClass = "")
        {
            var activeUserDelegations = await _userDelegationAppService.GetActiveUserDelegations();
            var model = new ActiveUserDelegationsComboboxViewModel
            {
                UserDelegations = activeUserDelegations,
                UserDelegationConfiguration = _userDelegationConfiguration
            };

            return View(model);
        }
    }
}
