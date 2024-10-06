using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Infrastructure.Persistence.Sql;

namespace Shop.Application.Tests.Integration.Utils;

public abstract class PersistTest : IDisposable
{
    private readonly IDbContextTransaction _scope;
    protected readonly DataBaseContext DbContext;
    protected PersistTest()
    {
        var connectionString =Constants.ConnectionString;
        DbContext = DatabaseContextFactory.Create(new SqlConnection(connectionString));
        _scope= DbContext.Database.BeginTransaction();
    }

    public void Dispose()
    {
        _scope.Rollback();
        DbContext.Dispose();
        _scope.Dispose();
    }
}