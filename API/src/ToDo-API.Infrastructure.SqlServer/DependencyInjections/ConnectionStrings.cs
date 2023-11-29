using System.Diagnostics.CodeAnalysis;

namespace ToDo_API.Infrastructure.SqlServer.DependencyInjections
{
    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string SqlConnectionString { get; set; }

        public ConnectionStrings() { }

        public ConnectionStrings(string sqlConnectionString)
        {
            SqlConnectionString = sqlConnectionString;
        }
    }
}
