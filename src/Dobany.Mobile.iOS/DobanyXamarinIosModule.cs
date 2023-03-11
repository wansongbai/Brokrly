using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany
{
    [DependsOn(typeof(DobanyXamarinSharedModule))]
    public class DobanyXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyXamarinIosModule).GetAssembly());
        }
    }
}