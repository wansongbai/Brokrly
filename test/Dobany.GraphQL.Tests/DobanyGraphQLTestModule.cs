using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Dobany.Configure;
using Dobany.Startup;
using Dobany.Test.Base;

namespace Dobany.GraphQL.Tests
{
    [DependsOn(
        typeof(DobanyGraphQLModule),
        typeof(DobanyTestBaseModule))]
    public class DobanyGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DobanyGraphQLTestModule).GetAssembly());
        }
    }
}