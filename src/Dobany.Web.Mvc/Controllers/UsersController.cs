using Abp.AspNetCore.Mvc.Authorization;
using Dobany.Authorization;
using Dobany.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Dobany.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}