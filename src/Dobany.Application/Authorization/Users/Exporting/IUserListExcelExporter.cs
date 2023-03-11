using System.Collections.Generic;
using Dobany.Authorization.Users.Dto;
using Dobany.Dto;

namespace Dobany.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}