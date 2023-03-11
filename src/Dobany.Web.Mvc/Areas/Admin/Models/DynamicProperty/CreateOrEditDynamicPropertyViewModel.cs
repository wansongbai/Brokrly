using System.Collections.Generic;
using Dobany.DynamicEntityProperties.Dto;

namespace Dobany.Web.Areas.Admin.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
