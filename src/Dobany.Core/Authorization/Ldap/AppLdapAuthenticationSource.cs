using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Dobany.Authorization.Users;
using Dobany.MultiTenancy;

namespace Dobany.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}