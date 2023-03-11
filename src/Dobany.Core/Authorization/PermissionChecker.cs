using Abp.Authorization;
using Dobany.Authorization.Roles;
using Dobany.Authorization.Users;

namespace Dobany.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
