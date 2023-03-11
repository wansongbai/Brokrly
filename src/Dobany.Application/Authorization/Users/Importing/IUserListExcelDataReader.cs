using System.Collections.Generic;
using Dobany.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Dobany.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
