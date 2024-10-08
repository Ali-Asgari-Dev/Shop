using FluentAssertions;
using Shop.Application.Services;
using Shop.Application.Tests.Integration.Utils;
using Shop.Application.Tests.Integration.Utils.Factories;
using Shop.Domain.Models.Categories;
using Shop.Domain.Models.Orders;
using Shop.Domain.Models.Products;
using Shop.Infrastructure.DomainServices;
using Shop.Infrastructure.Persistence.Sql.Repositories;

namespace Shop.Application.Tests.Integration;

public class OrderTests : PersistTest
{
    [Fact]
    public async Task order_apply_discount_when_customer_have_order()
    {
        var product = await CreateProduct();
        var customerId = Guid.NewGuid();
      var  lastOrder=await CreatePaidOrder(customerId,product,1);
        var order = await CreateOrder(customerId,product,1);
        await DbContext.SaveChangesAsync();
        var orderRepository = new OrderRepository(DbContext);
        var orderService = new OrderService(orderRepository,new ProductDomainService(new ProductRepository(DbContext)), new UnitOfDiscountCalculatorDomainService(orderRepository));
        await orderService.ApplyDiscount(new() { Id = order.Id });
        order.TotalFinalPrice.Should().Be(9000);
    }

    [Fact]
    public async Task order_apply_discount_when_customer_have_not_order()
    {
        var product = await CreateProduct();
        var order = await CreateOrder(Guid.NewGuid(),product,1);
        await DbContext.SaveChangesAsync();
        var orderRepository = new OrderRepository(DbContext);
        var orderService = new OrderService(orderRepository,new ProductDomainService(new ProductRepository(DbContext)), new UnitOfDiscountCalculatorDomainService(orderRepository));
        await orderService.ApplyDiscount(new() { Id = order.Id });
        order.TotalFinalPrice.Should().Be(10000);
    }

    private async Task<Order> CreateOrder(Guid customerId,Product product,int count)
    {
        var order = OrderTestFactory.New(customerId);
        order.AddItem(product.Id, count, product.Price);
        await DbContext.Orders.AddAsync(order);
        return order;
    }
    
    private async Task<Order> CreatePaidOrder(Guid customerId,Product product,int count)
    {
        var order = OrderTestFactory.New(customerId);
        order.AddItem(product.Id, count, product.Price);
        order.Paid();
        await DbContext.Orders.AddAsync(order);
        return order;
    }
    private async Task<Product> CreateProduct()
    {
        var category = await CreateCategory();
        var product = ProductFactory.New(category.Id, "test", null, 10000,5, category);
        await DbContext.Products.AddAsync(product);
        await DbContext.SaveChangesAsync();
        return product;
    }

    private async Task<Category> CreateCategory()
    {
        var category = new Category("test", 1000);
        await DbContext.Categories.AddAsync(category);
        await DbContext.SaveChangesAsync();
        return category;
    }
}