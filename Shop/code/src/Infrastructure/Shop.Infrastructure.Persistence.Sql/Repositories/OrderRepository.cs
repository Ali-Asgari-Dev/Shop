using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Orders;

namespace Shop.Infrastructure.Persistence.Sql.Repositories;

public class OrderRepository(DataBaseContext dbContext) : IOrderRepository
{
    public async Task<Order?> LastOrderByCustomerId(Guid customerId)
        => await dbContext.Orders.AsNoTracking()
            .Include(o=>o.Items).ThenInclude(o=>o.Product)
            .FirstOrDefaultAsync(o=>o.CustomerId==customerId);
}