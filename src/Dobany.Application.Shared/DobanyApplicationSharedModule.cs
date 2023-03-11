using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany
{
    [DependsOn(typeof(DobanyCoreSharedModule))]
    public class DobanyApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyApplicationSharedModule).GetAssembly());
        }
    }
}