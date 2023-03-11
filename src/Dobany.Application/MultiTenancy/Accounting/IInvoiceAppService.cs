﻿using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Dobany.MultiTenancy.Accounting.Dto;

namespace Dobany.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
