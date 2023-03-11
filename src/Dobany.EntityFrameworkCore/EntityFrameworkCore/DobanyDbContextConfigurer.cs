using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Dobany.EntityFrameworkCore
{
    public static class DobanyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DobanyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DobanyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}