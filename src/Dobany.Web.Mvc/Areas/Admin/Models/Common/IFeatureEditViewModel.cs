using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Dobany.Editions.Dto;

namespace Dobany.Web.Areas.Admin.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}