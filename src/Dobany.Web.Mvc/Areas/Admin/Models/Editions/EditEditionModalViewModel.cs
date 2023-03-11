using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Dobany.Editions.Dto;
using Dobany.Web.Areas.Admin.Models.Common;

namespace Dobany.Web.Areas.Admin.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionEditOutput))]
    public class EditEditionModalViewModel : GetEditionEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode => Edition.Id.HasValue;

        public IReadOnlyList<ComboboxItemDto> EditionItems { get; set; }

        public IReadOnlyList<ComboboxItemDto> FreeEditionItems { get; set; }
    }
}