using System.Collections.Generic;
using Dobany.DashboardCustomization.Dto;

namespace Dobany.Web.Areas.Admin.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
