using System.Collections.Generic;
using Dobany.DynamicEntityProperties.Dto;

namespace Dobany.Web.Areas.Admin.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}
