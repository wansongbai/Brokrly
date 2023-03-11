using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Dobany
{
    public class DobanyCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyCoreSharedModule).GetAssembly());
        }
    }
}