using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany.Startup
{
    [DependsOn(typeof(DobanyCoreModule))]
    public class DobanyGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}