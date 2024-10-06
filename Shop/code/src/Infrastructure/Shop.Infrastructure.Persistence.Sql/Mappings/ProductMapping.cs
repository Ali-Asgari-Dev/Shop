using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Products;

namespace Shop.Infrastructure.Persistence.Sql.Mappings;

    public class ProductMapping:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired(false);
        }
    }
