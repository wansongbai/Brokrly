using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using Abp.Organizations;
using Dobany.Authorization.Roles;
using System.Threading.Tasks;

namespace Dobany.Authorization.Users
{
    /// <summary>
    /// Used to perform database operations for <see cref="UserManager"/>.
    /// </summary>
    public class UserStore : AbpUserStore<Role, User>
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserClaim, long> userClaimRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
            : base(
                unitOfWorkManager,
                userRepository,
                roleRepository,
                userRoleRepository,
                userLoginRepository,
                userClaimRepository,
                userPermissionSettingRepository,
                userOrganizationUnitRepository,
                organizationUnitRoleRepository)
        {
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        #region 扩展方法
        /// <summary>
        /// Find By PhoneNumber
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public virtual async Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {

            return await _userRepository.FirstOrDefaultAsync(
                user => user.PhoneNumber == phoneNumber
                );
        }

        [UnitOfWork]
        public virtual async Task<User> FindByPhoneNumberAsync(int? tenantId, string phoneNumber)
        {
            using (_unitOfWorkManager.Current.SetTenantId(tenantId))
            {
                return await FindByPhoneNumberAsync(phoneNumber);
            }
        }
        #endregion
    }
}
