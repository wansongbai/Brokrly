using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Dobany.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=.\\SQLEXPRESS; Database=Dobany; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Dobany");
        }
    }
}
