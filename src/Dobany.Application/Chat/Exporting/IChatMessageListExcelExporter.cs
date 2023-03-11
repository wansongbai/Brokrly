using System.Collections.Generic;
using Abp;
using Dobany.Chat.Dto;
using Dobany.Dto;

namespace Dobany.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
