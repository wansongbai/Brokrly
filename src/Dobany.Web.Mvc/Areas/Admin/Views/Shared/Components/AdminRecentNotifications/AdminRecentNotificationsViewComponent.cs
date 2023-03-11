using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dobany.Web.Areas.Admin.Models.Layout;
using Dobany.Web.Views;

namespace Dobany.Web.Areas.Admin.Views.Shared.Components.AdminRecentNotifications
{
    public class AdminRecentNotificationsViewComponent : DobanyViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            var model = new RecentNotificationsViewModel
            {
                CssClass = cssClass
            };
            
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
