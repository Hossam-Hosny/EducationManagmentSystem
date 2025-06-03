using System.Data;

namespace Faculty_Student.Infrastructure.DbContext;

public interface IDbContext
{
    IDbConnection CreateConnection();
}
