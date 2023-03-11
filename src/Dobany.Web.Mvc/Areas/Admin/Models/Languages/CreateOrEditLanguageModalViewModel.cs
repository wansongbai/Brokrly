using Abp.AutoMapper;
using Dobany.Localization.Dto;

namespace Dobany.Web.Areas.Admin.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}