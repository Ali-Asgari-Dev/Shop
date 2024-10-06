using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistence.Sql;

namespace ServiceHost;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
        return builder;
    }
}