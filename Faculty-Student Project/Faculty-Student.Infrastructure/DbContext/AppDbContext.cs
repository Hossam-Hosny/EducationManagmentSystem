using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Faculty_Student.Infrastructure.AppDbContext;

public class AppDbContext(IConfiguration _config) : IDbContext
{
    public IDbConnection CreateConnection()
    {
        var connectionString = _config.GetConnectionString("LocalConnectionString");
        return new SqlConnection(connectionString);
    }
}
