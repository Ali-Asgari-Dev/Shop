using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Orders;

namespace Shop.Infrastructure.Persistence.Sql.Mappings;

public class OrderMapping:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order").HasKey(p => p.Id);
        builder.Property(a => a.State)
            .HasColumnName("State")
            .HasConversion(
                a => OrderStateValueFactory.GetValue(a.GetType()),
                a => OrderStateValueFactory.GetState(a)
            );    }
}
public class OrderItemMapping:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem").HasKey(s=>s.Id);
        builder.Property(x => x.Count).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.HasOne(p => p.Order).WithMany(p => p.Items).HasForeignKey(p => p.OrderId);

    }
}