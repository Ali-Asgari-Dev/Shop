using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Tests.Integration.Utils;

public static class DbContextExtensions
{
    public static void DetachAllEntities(this DbContext context)
    {
        var changedEntriesCopy = context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
            .ToList();
        foreach (var entry in changedEntriesCopy) entry.State = EntityState.Detached;
    }
}