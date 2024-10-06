using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Categories;

namespace Shop.Infrastructure.Persistence.Sql.Mappings;

public class CategoryMapping:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category").HasKey(p => p.Id);
        builder.Property(p => p.Title).HasMaxLength(300).IsRequired();
    }
}