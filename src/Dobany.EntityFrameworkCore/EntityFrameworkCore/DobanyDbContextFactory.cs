using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Dobany.Configuration;
using Dobany.Web;

namespace Dobany.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DobanyDbContextFactory : IDesignTimeDbContextFactory<DobanyDbContext>
    {
        public DobanyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DobanyDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            DobanyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DobanyConsts.ConnectionStringName));

            return new DobanyDbContext(builder.Options);
        }
    }
}