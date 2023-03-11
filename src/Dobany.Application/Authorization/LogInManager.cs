using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Dobany.Authorization.Roles;
using Dobany.Authorization.Users;
using Dobany.MultiTenancy;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.UI;
using Abp.Timing;
using Dobany.Authorization.Accounts;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Dobany.Url;
using Abp.Runtime.Caching;
using Dobany.Authorization.Users.Profile.Cache;

namespace Dobany.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly UserManager _userManager;
        private readonly UserStore _userStore;
        private readonly UserClaimsPrincipalFactory _claimsPrincipalFactory;
        private readonly IAccountAppService _accountAppService;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly ICacheManager _cacheManager;
        public IAppUrlService AppUrlService { get; set; }

        public LogInManager(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher,
            UserClaimsPrincipalFactory claimsPrincipalFactory,
            UserStore userStore,
            IAccountAppService accountAppService,
            UserRegistrationManager userRegistrationManager,
            ICacheManager cacheManager)
            : base(
                  userManager,
                  multiTenancyConfig,
                  tenantRepository,
                  unitOfWorkManager,
                  settingManager,
                  userLoginAttemptRepository,
                  userManagementConfig,
                  iocResolver,
                  passwordHasher,
                  roleManager,
                  claimsPrincipalFactory)
        {
            _multiTenancyConfig = multiTenancyConfig;
            _unitOfWorkManager = unitOfWorkManager;
            _tenantRepository = tenantRepository;
            _userManager = userManager;
            _userStore = userStore;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            _accountAppService = accountAppService;
            _userRegistrationManager = userRegistrationManager;
            AppUrlService = NullAppUrlService.Instance;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// �ֻ���֤���½
        /// </summary>
        /// <param name="phoneNumber">�ֻ���</param>
        /// <param name="captcha">��֤��</param>
        /// <param name="tenantName">�⻧��</param>
        /// <param name="shouldLockout">�Ƿ�����</param>
        /// <param name="nickName">�ǳ�</param>
        /// <returns></returns>
        public virtual async Task<AbpLoginResult<Tenant, User>> LoginByMobileAsync(string phoneNumber, string captcha,
            string tenantName = null, bool shouldLockout = false, string nickName = "")
        {
            var result = await LoginByMobileAsyncInternal(phoneNumber, captcha, tenantName, shouldLockout, nickName);
            //TODO:
            //await SaveLoginAttempt(result, tenantName, result.User.UserName);
            return result;
        }

        /// <summary>
        /// �ֻ���֤���½�ڲ�����
        /// </summary>
        /// <param name="phoneNumber">�ֻ���</param>
        /// <param name="captcha">��֤��</param>
        /// <param name="tenantName">�⻧��</param>
        /// <param name="shouldLockout">�Ƿ�����</param>
        /// <param name="nickName">�ǳ�</param>
        /// <returns></returns>
        protected virtual async Task<AbpLoginResult<Tenant, User>> LoginByMobileAsyncInternal(string phoneNumber,
            string captcha, string tenantName, bool shouldLockout, string nickName)
        {
            if (phoneNumber.IsNullOrEmpty())
            {
                //Logger.Error("�ֻ��Ų���Ϊ��");
                throw new UserFriendlyException("�ֻ��Ų���Ϊ��");
            }
            //��ȡ�ͼ���⻧
            Tenant tenant = null;
            //���õ�ǰ�⻧idΪ��
            using (_unitOfWorkManager.Current.SetTenantId(null))
            {
                //����ر��⻧�ͻ�ȡĬ���⻧
                if (!_multiTenancyConfig.IsEnabled)
                {
                    //��ȡĬ���⻧
                    tenant = await GetDefaultTenantAsync();
                }
                //�⻧id�Ƿ�Ϊ��
                else if (!string.IsNullOrWhiteSpace(tenantName))
                {
                    //��ѯ�⻧��Ϣ
                    tenant = await _tenantRepository.FirstOrDefaultAsync(model => model.TenancyName == tenantName);
                    if (tenant == null)
                        //������Ч�⻧
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidTenancyName);
                    if (!tenant.IsActive)
                        //�����⻧δ����
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.TenantIsNotActive, tenant);
                }
            }
            //�����⻧id
            var tenantId = tenant == null ? (int?)null : tenant.Id;
            //���õ�ǰ�⻧id
            using (_unitOfWorkManager.Current.SetTenantId(tenantId))
            {
                //��ʼ��ѡ��
                await _userManager.InitializeOptionsAsync(tenantId);
                var loggedInFromExternalSource = false;
                //ͨ���ֻ��Ų�ѯ�û�
                var user = await _userStore.FindByPhoneNumberAsync(tenantId, phoneNumber);
                if (user == null)
                {
                    //�ô��ֻ��Ž���ע��
                    var inputEmailAddress = phoneNumber + "@139.com";
                    var inputName = "U" + phoneNumber;
                    var inputPassword = "pwd5674" + phoneNumber;
                    var inputSurname = "S" + phoneNumber;
                    var inputUserName = "UN" + phoneNumber;

                    user = await _userRegistrationManager.RegisterAsync(
                            inputName,
                            inputSurname,
                            inputEmailAddress,
                            inputUserName,
                            inputPassword,
                            false,
                            AppUrlService.CreateEmailActivationUrlFormat(tenantId),
                            nickName);

                    //������Ч�û�
                    //return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidUserNameOrEmailAddress, tenant);
                }
                //�û��Ƿ�����
                if (await _userManager.IsLockedOutAsync(user))
                    //���������û�
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                if (!loggedInFromExternalSource)
                {
                    //��֤����֤
                    if (!await CheckCaptcha(phoneNumber, captcha))
                    {
                        //�Ƿ�����
                        if (shouldLockout)
                        {
                            //�����˻�
                            if (await TryLockOutAsync(tenantId, user.Id))
                                //���������˻�
                                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                        }
                        //������Ч����
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidPassword, tenant, user);
                    }
                    //���õ�½ʧ�ܴ���
                    await UserManager.ResetAccessFailedCountAsync(user);
                }
                return await CreateLoginByMobileResultAsync(user, tenant, phoneNumber);
            }
        }

        /// <summary>
        /// �����֤��
        /// </summary>
        /// <param name="phoneNumber">����</param>
        /// <param name="captcha">��֤��</param>
        /// <returns></returns>
        public async Task<bool> CheckCaptcha(string phoneNumber, string captcha)
        {
            //TODO:
            //var entity = await _smsCaptchaRepository.FirstOrDefaultAsync(model => model.PhoneNumer == user.PhoneNumber);
            //if (entity.Captcha == captcha)
            //    return true;
            //return false;


            return true;
            //TODO
            //var cash = await _cacheManager.GetSmsVerificationCodeCache().GetOrDefaultAsync(phoneNumber);

            //return cash.Code == captcha;
        }

        /// <summary>
        /// �����ֻ��ŵ�½���
        /// </summary>
        /// <param name="user">�û�</param>
        /// <param name="tenant">�⻧</param>
        /// <returns></returns>
        protected virtual async Task<AbpLoginResult<Tenant, User>> CreateLoginByMobileResultAsync(User user,
            Tenant tenant = null, string phoneNumber = null)
        {
            //�û�δ����
            if (!user.IsActive)
                //�����û�δ����
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserIsNotActive, tenant, user);
            //�û��ֻ���δ��֤
            if (user.IsPhoneNumberConfirmed)
                //�����û��ֻ���δ��֤
                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.UserPhoneNumberIsNotConfirmed, tenant, user);
            //user.LockoutEndDateUtc = Clock.Now;
            user.PhoneNumber = phoneNumber;

            //�����û�
            await _userManager.UpdateAsync(user);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            var principal = await _claimsPrincipalFactory.CreateAsync(user);

            //clear phonenumber cache
            _cacheManager.GetSmsVerificationCodeCache().Remove(user.PhoneNumber);

            return new AbpLoginResult<Tenant, User>(
                tenant,
                user,
                (System.Security.Claims.ClaimsIdentity)principal.Identity);
        }
    }
}