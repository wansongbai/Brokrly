using System.Collections.Generic;
using Dobany.Caching.Dto;

namespace Dobany.Web.Areas.Admin.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}