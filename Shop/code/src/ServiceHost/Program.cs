using ServiceHost;
using Shop.Application.Contracts;
using Shop.Application.Services;
using Shop.Domain.Models.Categories;
using Shop.Domain.Models.Orders;
using Shop.Domain.Models.Products;
using Shop.Domain.Services;
using Shop.Infrastructure.DomainServices;
using Shop.Infrastructure.Persistence.Sql.Repositories;
using OrderService = Shop.Application.Services.OrderService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.AddDatabase();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUnitOfDiscountCalculatorDomainService, UnitOfDiscountCalculatorDomainService>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
app.MapControllers();

// app.UseHttpsRedirection();

app.Run();
