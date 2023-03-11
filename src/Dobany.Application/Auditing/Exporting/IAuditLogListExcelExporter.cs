using System.Collections.Generic;
using Dobany.Auditing.Dto;
using Dobany.Dto;

namespace Dobany.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
