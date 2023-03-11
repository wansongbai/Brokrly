using System.Collections.Generic;
using Dobany.Authorization.Users.Importing.Dto;
using Dobany.Dto;

namespace Dobany.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
