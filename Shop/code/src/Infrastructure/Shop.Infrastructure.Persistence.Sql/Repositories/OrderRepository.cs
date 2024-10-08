using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Orders;

namespace Shop.Infrastructure.Persistence.Sql.Repositories;

public class OrderRepository(DataBaseContext dbContext) : IOrderRepository
{
    
    public async Task<Order?> LastOrderByCustomerId(Guid customerId)
        => await dbContext.Orders.AsNoTracking()
            .Include(o=>o.Items).ThenInclude(o=>o.Product)
            .FirstOrDefaultAsync(o=>o.State==OrderState.PaidState()&&o.CustomerId==customerId);

    public async Task<Order?> GetIncludeItemById(Guid id) => await dbContext.Orders.Include(o=>o.Items).FirstOrDefaultAsync(o=>o.Id==id);
    public async Task<Order?> FindById(Guid id) => await dbContext.Orders.FindAsync(id);

    public async Task Save()
        => await dbContext.SaveChangesAsync();

    public async Task CreateOrder(Order order)
        => await dbContext.Orders.AddAsync(order);
}