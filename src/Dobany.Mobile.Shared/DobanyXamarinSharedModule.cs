using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany
{
    [DependsOn(typeof(DobanyClientModule), typeof(AbpAutoMapperModule))]
    public class DobanyXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyXamarinSharedModule).GetAssembly());
        }
    }
}