using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Dobany.Authorization;

namespace Dobany
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(DobanyApplicationSharedModule),
        typeof(DobanyCoreModule)
        )]
    public class DobanyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyApplicationModule).GetAssembly());
        }
    }
}