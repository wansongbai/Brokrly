using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Dobany.Dto;

namespace Dobany.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
