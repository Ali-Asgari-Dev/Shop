using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Persistence.Sql;

public static class DatabaseContextFactory
{
    public static DataBaseContext Create(DbConnection connection)
    {
        var builder = new DbContextOptionsBuilder<DataBaseContext>();
        builder.UseSqlServer(connection);
        return new DataBaseContext(builder.Options);
    }
}