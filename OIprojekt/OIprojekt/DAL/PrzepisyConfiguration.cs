using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace OIprojekt.DAL
{
    public class PrzepisyConfiguration : DbConfiguration
    {
        public PrzepisyConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}