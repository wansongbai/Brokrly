using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Components.AdminChatToggler
{
    public class AdminChatTogglerViewComponent : DobanyViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new ChatTogglerViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
