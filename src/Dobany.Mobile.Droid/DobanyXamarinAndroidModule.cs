using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany
{
    [DependsOn(typeof(DobanyXamarinSharedModule))]
    public class DobanyXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyXamarinAndroidModule).GetAssembly());
        }
    }
}