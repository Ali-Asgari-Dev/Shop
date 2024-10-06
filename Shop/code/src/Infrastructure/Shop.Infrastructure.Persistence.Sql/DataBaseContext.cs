using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Domain.Models.Categories;
using Shop.Domain.Models.Customers;
using Shop.Domain.Models.Orders;
using Shop.Domain.Models.Products;
using Shop.Infrastructure.Persistence.Sql.Mappings;

namespace Shop.Infrastructure.Persistence.Sql;

public class DataBaseContext:DbContext
{
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DataBaseContext(IRequestContext requestContext)
        {
            
        }
        public DataBaseContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMapping).Assembly);
        }
   
    }